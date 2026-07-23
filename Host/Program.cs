using Core.Furion.Component.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).Inject();

            //启用跨域Cors
            builder.Services.AddCorsAccessor();

            //服务组件，必须在AddControllersWithViews或者AddControllers之前，自定义授权才有效
            builder.Services.AddComponent<HostComponent>();
            builder.Services.AddControllers() //.AddControllersWithViews()
                .AddNewtonsoftJson(opt =>
                {
                    //接口输出日期格式化
                    opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                    //如果需要设置特定文化区域，例如中国时区
                    opt.SerializerSettings.Culture = new CultureInfo("zh-CN");
                    //序列化属性名大写（属性原样输出）
                    //opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //动态对象后发现属性名出现了大写情况（首字母），这个时候可以尝试使用以下方法解决
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //Clay 为动态类型对象，不支持直接通过 System.Text.Json 和 Newtonsoft.Json 进行序列
                    //序列化和反序列化，这时只需添加以下配置
                    opt.SerializerSettings.Converters.AddClayConverters();
                    //将 long 类型序列化时转为 string 类型，防止 JavaScript 出现精度溢出问题
                    opt.SerializerSettings.Converters.AddLongTypeConverters();
                    //忽略循环引用
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //JSON 字符串缩进
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                })
                .AddJsonOptions(options =>
                {
                    //Swagger参数属性大小写问题,若需要处理字典键的小驼峰，与（opt.SerializerSettings.ContractResolver = new DefaultContractResolver();）配合使用
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    //若需要处理字典键的小驼峰
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    //不区分大小写
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    //处理（中文）乱码问题
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                    //只能将枚举转换为数字或将数字转换为枚举对象，也可以通过局部或全局配置实现字符串互转
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.AddDateTimeTypeConverters(); // 时间序列化处理
                    options.JsonSerializerOptions.Converters.AddClayConverters(); //Clay类型类型序列化处理
                    //忽略循环引用
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    //允许尾随逗号
                    options.JsonSerializerOptions.AllowTrailingCommas = true;
                    //允许注释
                    options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                    //JSON 字符串缩进
                    options.JsonSerializerOptions.WriteIndented = true;
                })
                .AddXmlDataContractSerializerFormatters()
                .AddInject(_ =>
                {
                    //x.ConfigureSwaggerGen(swo => swo.OperationFilter<ShowActualMethodNameFilter>());
                })
                .AddInjectWithUnifyResult<UnifyApiResultProvider>() //包含友好的异常服务,自定义统一返回值
                .AddAppLocalization(setting => //注册多语言
                {
                    //扩展第三方本地化
                    builder.Services.AddJsonLocalization(options =>
                    {
                        options.ResourcesPath = [setting.ResourcesPath];
                    });
                });

            var app = builder.Build();

            //配置多语言，必须在 路由注册之前
            app.UseAppLocalization();

            //app.UseForwardedHeaders();

            //如果使用文件系统模块，则注释掉
            app.UseStaticFiles()
                .UseDefaultFiles();

            //添加路由
            app.UseRouting();

            //跨域中间件,需在app.UseAuthentication(); 之前
            app.UseCorsAccessor();

            //添加认证
            app.UseAuthentication();

            app.EnableBuffering();
            app.UseHttpsRedirection();

            //添加授权
            app.UseAuthorization();

            //默认情况下，规范化结果不会对 401 和 403、404 状态码进行规范化处理
            app.UseUnifyResultStatusCodes();

            app.UseComponent<HostComponent>(app.Environment);

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
