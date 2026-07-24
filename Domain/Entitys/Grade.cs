using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "年级信息表")]
    public class Grade : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 年级编码
        /// </summary>
        [SugarColumn(ColumnDescription = "年级编码", Length = 20, CreateTableFieldSort = 10)]
        public string? GradeCode { get; set; }

        /// <summary>
        /// 年级负责人ID列表
        /// </summary>
        [SugarColumn(ColumnDescription = "年级负责人", CreateTableFieldSort = 20)]
        public List<string>? GradeManagers { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        [SugarColumn(ColumnDescription = "学校ID", CreateTableFieldSort = 30)]
        public string? SchoolId { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 学校信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(SchoolId), nameof(School.Id))]
        public School? SchoolData { get; set; }

        /// <summary>
        /// 年级负责人信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(GradeManagers), nameof(Teacher.Id))]
        public Teacher? TeacherData { get; set; }
    }
}
