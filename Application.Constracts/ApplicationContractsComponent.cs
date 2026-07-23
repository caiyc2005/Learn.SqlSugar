using Domain.Shared;
using Furion;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Application.Constracts;

/// <summary>
/// 应用定义
/// </summary>
[DependsOn(
    typeof(DomainSharedComponent)
)]
public class ApplicationContractsComponent : IServiceComponent, IApplicationComponent
{
    /// <summary>
    /// 注册服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="componentContext"></param>
    public void Load(IServiceCollection services, ComponentContext componentContext)
    {
    }

    /// <summary>
    /// 注入中间件
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="componentContext"></param>
    public void Load(IApplicationBuilder app, IWebHostEnvironment env, ComponentContext componentContext)
    {
    }
}