using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "学校信息表")]
    public class School : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 学校编码
        /// </summary>
        [SugarColumn(ColumnDescription = "学校编码", Length = 20, CreateTableFieldSort = 10)]
        public string? SchoolCode { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [SugarColumn(ColumnDescription = "学校名称", Length = 100, CreateTableFieldSort = 20)]
        public string? SchoolName { get; set; }

        /// <summary>
        /// 学校Logo
        /// </summary>
        [SugarColumn(ColumnDescription = "学校Logo", Length = 200, CreateTableFieldSort = 30)]
        public string? SchoolLogo { get; set; }

        /// <summary>
        /// 学校校长姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "校长姓名", Length = 100, CreateTableFieldSort = 40)]
        public string? SchoolManager { get; set; }

        /// <summary>
        /// 学校地址
        /// </summary>
        [SugarColumn(ColumnDescription = "学校地址", Length = 200, CreateTableFieldSort = 50)]
        public string? SchoolAddress { get; set; }

        /// <summary>
        /// 学校简介
        /// </summary>
        [SugarColumn(ColumnDescription = "学校简介", Length = 500, CreateTableFieldSort = 60)]
        public string? SchoolDescription { get; set; }

        /// <summary>
        /// 学校创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "学校创建时间", CreateTableFieldSort = 100)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 学校校长最新换届时间
        /// </summary>
        [SugarColumn(ColumnDescription = "学校校长最新换届时间", CreateTableFieldSort = 200)]
        public DateTime? ManagerUpdateDate { get; set; }

        //*************************************导航*************************************
        /// <summary>
        /// 学校的年级信息
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(Grade.SchoolId))]
        public List<Grade>? GradeList { get; set; }

    }
}
