namespace Domain.Migrators;

/// <summary>
/// DB数据库迁移
/// </summary>
public interface IDbSchemaMigrator
{
    /// <summary>
    /// 生成迁移数据库和表
    /// </summary>
    void MigrateAsync();
}