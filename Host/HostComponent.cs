using Core.Furion.Component.Extenssions;
using Application;
using Domain.Migrators;
using Domain.Migrators.DataSeeders;

namespace Host
{
    /// <summary>
    /// 应用层
    /// </summary>
    [DependsOn(
        typeof(ApplicationComponent)
    )]
    public class HostComponent : IServiceComponent, IApplicationComponent
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="componentContext"></param>
        public void Load(IServiceCollection services, ComponentContext componentContext)
        {
            var headerAuthStr = "Authorization";
            //添加Jwt自定义授权验证,全局接口需要Token验证(enableGlobalAuthorize:true)不需要添加Anthorize特性
            services.AddJwt<JwtHandler>(jwtBearerConfigure: options =>
            {
                options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                {
                    //添加额外 Token 读取处理
                    //可以在这里实现任何方式的读取 Token，然后设置给 context.Token 即可
                    OnMessageReceived = context =>
                    {
                        //添加读取 Token 的方式
                        var httpContext = context.HttpContext;
                        //判断请求是否包含 Authorization 参数，如果有就设置给 Token
                        if (httpContext.Request.Query.ContainsKey(headerAuthStr))
                        {
                            //设置 Token
                            context.Token = httpContext.Request.Query[headerAuthStr];
                        }

                        return Task.CompletedTask;
                    },
                    //Token 验证通过处理
                    OnTokenValidated = _ => Task.CompletedTask,
                    //Token 验证失败处理
                    OnAuthenticationFailed = _ => Task.CompletedTask,
                    //客户端未提供 Token 或 Token 格式不正确处理
                    OnChallenge = _ => Task.CompletedTask
                };
            }, enableGlobalAuthorize: true);
        }

        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="componentContext"></param>
        public void Load(IApplicationBuilder app, IWebHostEnvironment env, ComponentContext componentContext)
        {
            //if (!env.IsProduction())
            //{
            //生成库+生成表
            var createDB = app.ApplicationServices
                .GetRequiredService<DbSchemaMigrationService>()
                .MigrateAsync();

            if (createDB)
            {
                // //生成种子数据
                // var dataSeeds = app.ApplicationServices.GetRequiredService<IDataSeeder>();
                // dataSeeds?.SeedAsync();

                var dataSeeds = app.ApplicationServices.GetRequiredService<IEnumerable<IDataSeeder>>();
                if (!dataSeeds.IsNullOrNotValue())
                {
                    foreach (var dataSeed in dataSeeds)
                    {
                        dataSeed.SeedAsync();
                    }
                }
            }
            //}
        }
    }
}