using Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

/// <summary>
/// 领域层
/// </summary>
[DependsOn(
    typeof(DomainSharedComponent)
)]
public class DomainComponent : IServiceComponent
{
    /// <summary>
    /// 注册服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="componentContext"></param>
    public void Load(IServiceCollection services, ComponentContext componentContext)
    {
    }
}