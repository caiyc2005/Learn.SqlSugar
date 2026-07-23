namespace Domain.Migrators.DataSeeders;

/// <summary>
/// 种子数据
/// </summary>
public class DataSeeder : IDataSeeder, ITransient
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DataSeeder> _logger;

    public DataSeeder(IServiceProvider serviceProvider, ILogger<DataSeeder> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public async Task SeedAsync()
    {
        await Task.CompletedTask;
    }
}