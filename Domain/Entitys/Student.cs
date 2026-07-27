using Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "学生信息表")]
    public class Student : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 学号
        /// </summary>
        [SugarColumn(ColumnDescription = "学生学号", Length = 20, CreateTableFieldSort = 10)]
        public string? StudentCode { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "学生姓名", Length = 20, CreateTableFieldSort = 20)]
        public string? StudentName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        [SugarColumn(ColumnDescription = "班级ID", CreateTableFieldSort = 30)]
        public Guid? ClassId { get; set; }


        /// <summary>
        /// 学生类型
        /// </summary>
        [SugarColumn(ColumnDescription = "学生类型", CreateTableFieldSort = 50)]
        public StuTypeEnum StuType { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 班级信息
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(ClassId), nameof(Class.Id))]
        public Class? ClassData { get; set; }

        /// <summary>
        /// 家长信息，一对多
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(Parent.StudentId))]
        public List<Parent> ParentList { get; set; }

    }
}
