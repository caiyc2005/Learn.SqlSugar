using Furion.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Domain.Migrators;


/// <summary>
/// 迁移服务
/// </summary>
public class DbSchemaMigrationService : ITransient
{
    private readonly IEnumerable<IDbSchemaMigrator> _dbSchemaMigrators;
    private readonly ILogger<DbSchemaMigrationService> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbSchemaMigrators"></param>
    /// <param name="logger"></param>
    public DbSchemaMigrationService(IEnumerable<IDbSchemaMigrator> dbSchemaMigrators,
        ILogger<DbSchemaMigrationService> logger)
    {
        _dbSchemaMigrators = dbSchemaMigrators;
        _logger = logger;
    }

    /// <summary>
    /// 生成迁移数据库和表
    /// </summary>
    /// <returns></returns>
    public bool MigrateAsync()
    {
        _logger.LogInformation("开始主机数据库迁移 ==》 Begin Host DataBase Migrations.");

        MigrateDatabaseSchemaAsync();

        _logger.LogInformation("成功完成所有数据库和表的迁移 ==》 Successfully Completed All DataBase Migrations.");
        _logger.LogInformation("You Can Safely End This Process...");

        return true;
    }

    /// <summary>
    /// 遍历Product下所有的MigrateAsync
    /// </summary>
    /// <returns></returns>
    private void MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            migrator.MigrateAsync();
        }
    }
}