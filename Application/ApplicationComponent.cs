using Application.Constracts;
using Core.Furion.Component;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// 应用
/// </summary>
[DependsOn(
    typeof(ApplicationContractsComponent),
    typeof(DomainComponent)
)]
public class ApplicationComponent : IServiceComponent, IApplicationComponent
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
    /// 注册中间件
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="componentContext"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Load(IApplicationBuilder app, IWebHostEnvironment env, ComponentContext componentContext)
    {
   
    }

}