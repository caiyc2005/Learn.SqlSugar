using Furion.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Host
{
    /// <summary>
    /// Jwt Token自定义验证
    /// </summary>
    public class JwtHandler : AppAuthorizeHandler
    {
        /// <summary>
        /// 自定义权限验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
        {
            // using var serviceScope = httpContext.ServiceScopeFactory.CreateScope();
            // var currentUser = serviceScope.ServiceProvider.GetRequiredService<ICurrentUser>();
            //
            // if (currentUser.AccountType == (int)SysUserAccountTypeEnum.SuperAdmin)
            //     return true;
            //
            // //如果是推广app登录 则判断登录的flag
            // if (currentUser.Multiport == (int)MultiportEnum.AppPromotionApp)
            // {
            //     var onlieUserResource = serviceScope.ServiceProvider.GetRequiredService<AppOnlineUserResource>();
            //     if (!await onlieUserResource.CheckFlagAsync(Guid.Parse(currentUser.Code), currentUser.PlatformId, (MultiportEnum)currentUser.Multiport, currentUser.Flag))
            //     {
            //         await httpContext.Response.WriteAsJsonAsync(new UnifyApiResult<object> { Code = StatusCodes.Status401Unauthorized, Message = "您的登录信息已过期" },
            //                                                     App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
            //         context.Fail();
            //         return true;
            //     }
            // }
            //
            // //路由名称
            // var endpoint = httpContext.GetEndpoint();
            // if (endpoint == null)
            //     return true;
            //
            // var requestAction = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            // if (requestAction == null)
            //     return true;
            //
            // var requestPerm = $":{requestAction.ControllerName}:{requestAction.MethodInfo.Name}";
            // var sysMenuService = serviceScope.ServiceProvider.GetRequiredService<SysMenuService>();
            //
            // //获取用户拥有按钮权限集合
            // var ownBtnPermList = (await sysMenuService.GetCurrentUserBtnPermList()).SelectMany(x => x.BtnPermList).ToList();
            // if (ownBtnPermList.Exists(u => u.Permission.EndsWith(requestPerm, StringComparison.OrdinalIgnoreCase)))
            //     return true;
            //
            // //获取系统所有按钮权限集合
            // var allBtnPermList = await sysMenuService.GetAllBtnPermList(currentUser.PlatformId);
            //
            // //当请求的接口不在用户按钮权限中时，又在所有按钮权限中则无权限 反之则视为非按钮接口，允许请求
            // return allBtnPermList.TrueForAll(u => !u.EndsWith(requestPerm, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(true);
        }
    }
}