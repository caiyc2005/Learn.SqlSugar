using System.Reflection;
using Core.Furion.Component.Extenssions;
using Furion;
using Furion.DependencyInjection;
using Furion.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;
using SqlSugarCoreExtra.Furion.Component;

namespace Domain.Migrators;

/// <summary>
/// 初始Migrator表结构
/// </summary>
public class DbSchemaMigrator : IDbSchemaMigrator, ITransient
{
    private readonly ILogger<DbSchemaMigrator> _logger;
    private readonly ConnectionExtraSettingsOptions _options;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    public DbSchemaMigrator(IOptions<ConnectionExtraSettingsOptions> options,
        ILogger<DbSchemaMigrator> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    /// <summary>
    /// 迁移
    /// </summary>
    public void MigrateAsync()
    {
        if (_options.ConnectionConfigList.IsNullOrNotValue())
            return;

        var codeFirstDBList =
            _options.ConnectionConfigList.Where(x => x.CodeFirst && x.ConfigId.ToString() == DBConst.Education);
        if (codeFirstDBList.IsNullOrNotValue())
            return;

        var entityMultipleTypes = App.Assemblies.SelectMany(s => s.GetTypes())
            .Where(p => !p.IsInterface)
            .Where(p => p.GetCustomAttribute<TenantAttribute>() != null &&
                        p.GetCustomAttribute<TenantAttribute>()?.configId.ToString() == DBConst.Education)
            .Where(p => p.GetCustomAttribute<SugarTable>() != null);

        if (entityMultipleTypes.IsNullOrNotValue())
            return;

        if (App.GetService<ISqlSugarClient>() is not SqlSugarClient sqlScope)
            return;

        try
        {
            //生成库
            foreach (var item in codeFirstDBList)
            {
                var provider = sqlScope.GetConnection(item.ConfigId);
                provider.DbMaintenance.CreateDatabase();
            }

            //生成表
            var codeFirst = sqlScope.CodeFirst
                .SetStringDefaultLength(200)
                .BackupTable();

            foreach (var tableType in entityMultipleTypes)
            {
                Log.Information($"迁移表【{tableType.Name}】.....开始");
                codeFirst.InitTablesWithAttr(tableType);
                Log.Information($"迁移表【{tableType.Name}】.....结束");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("生成库表异常{ExMessage}", ex.Message);
        }


        #region v2

        // try
        // {
        //     //生成库
        //     foreach (var item in _options.ConnectionConfigList)
        //     {
        //         var provider = DbManger.Db.GetConnectionScope(item.ConfigId);
        //         var buildDB = provider.DbMaintenance.CreateDatabase();
        //         if (buildDB)
        //         {
        //             //生成表
        //             var codeFirst = provider.CodeFirst
        //                 .SetStringDefaultLength(200)
        //                 .BackupTable();
        //
        //             var attr_entityList = entityMultipleTypes.Where(x =>
        //                 x.GetCustomAttribute<TenantAttribute>()?.configId.ToString() == item.ConfigId.ToString());
        //             foreach (var tableType in attr_entityList)
        //             {
        //                 Log.Information($"迁移表【{tableType.Name}】.....开始");
        //                 codeFirst.InitTablesWithAttr(tableType);
        //                 Log.Information($"迁移表【{tableType.Name}】.....结束");
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     _logger.LogError("生成库表异常{ExMessage}", ex.Message);
        // }

        #endregion
    }
}