namespace Domain.Migrators.DataSeeders;

/// <summary>
/// 种子数据接口
/// </summary>
public interface IDataSeeder
{
    /// <summary>
    /// 初始化种子
    /// </summary>
    /// <returns></returns>
    Task SeedAsync();
}