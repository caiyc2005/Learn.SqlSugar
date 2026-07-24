using SqlSugarCoreExtra.Furion.Component.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "教师信息表")]
    public class Teacher : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnDescription = "工号", Length = 20, CreateTableFieldSort = 10)]
        public string? TeacherCode { get; set; }

        /// <summary>
        /// 教师姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "教师姓名", Length = 20, CreateTableFieldSort = 20)]
        public string? TeacherName { get; set; }

        /// <summary>
        /// 教师电话
        /// </summary>
        [SugarColumn(ColumnDescription = "教师电话", Length = 20, CreateTableFieldSort = 30)]
        public string? TeacherPhone { get; set; }

        /// <summary>
        /// 教师邮箱
        /// </summary>
        [SugarColumn(ColumnDescription = "教师邮箱", Length = 50, CreateTableFieldSort = 40)]
        public string? TeacherEmail { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [SugarColumn(ColumnDescription = "入职时间", CreateTableFieldSort = 70)]
        public DateTime? TeacherInDate { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        [SugarColumn(ColumnDescription = "离职时间", CreateTableFieldSort = 80)]
        public DateTime? TeacherOutDate { get; set; }

        //*************************************导航*************************************

    }
}
