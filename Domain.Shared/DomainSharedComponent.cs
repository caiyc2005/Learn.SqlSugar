using Microsoft.Extensions.DependencyInjection;
using SqlSugarCoreExtra.Furion.Component;

namespace Domain.Shared;

/// <summary>
/// 共享层
/// </summary>
[DependsOn(
    typeof(SqlSugarCoreExtraNoCacheComponent) //无缓存版本
)]
public class DomainSharedComponent : IServiceComponent
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