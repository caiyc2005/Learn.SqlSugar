using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "家长信息表")]
    public class Parent : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 家长编码
        /// </summary>
        [SugarColumn(ColumnDescription = "家长编码", Length = 20, CreateTableFieldSort = 10)]
        public string? ParentCode { get; set; }

        /// <summary>
        /// 家长姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "家长姓名", Length = 20, CreateTableFieldSort = 20)]
        public string? ParentName { get; set; }

        /// <summary>
        /// 家长联系方式
        /// </summary>
        [SugarColumn(ColumnDescription = "家长联系方式", Length = 20, CreateTableFieldSort = 30)]
        public string? ParentPhone { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        [SugarColumn(ColumnDescription = "学生ID", Length = 50, CreateTableFieldSort = 50)]
        public Guid? StudentId { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 学生信息
        /// </summary>
        //多对一，多对一就是一对一
        [Navigate(NavigateType.OneToOne, nameof(StudentId),nameof(Student.Id))]
        public Student? StudentData { get; set; }
    }
}
