using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;

namespace Domain.Entitys
{
    [Tenant(DBConst.Education)]
    [SugarTable(TableDescription = "班级信息表")]
    public class Class : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 班级编码
        /// </summary>
        [SugarColumn(ColumnDescription = "班级编码", IsNullable = false, Length = 20, CreateTableFieldSort = 10)]
        public string? ClassCode { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [SugarColumn(ColumnDescription = "班级名称", Length = 20, CreateTableFieldSort = 20)]
        public string? ClassName { get; set; }

        /// <summary>
        /// 班主任ID
        /// </summary>
        [SugarColumn(ColumnDescription = "班主任ID", Length = 50, CreateTableFieldSort = 30)]
        public Guid? TeacherId { get; set; }

        /// <summary>
        /// 班主任姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "班主任姓名", Length = 30, CreateTableFieldSort = 40)]
        public string? TeacherName { get; set; }

        /// <summary>
        /// 班级人数
        /// </summary>
        [SugarColumn(ColumnDescription = "班级人数",  CreateTableFieldSort = 50)]
        public int SumNum { get; set; } = 0;

        /// <summary>
        /// 所属年级ID
        /// </summary>
        [SugarColumn(ColumnDescription = "所属年级ID", CreateTableFieldSort = 60)]
        public Guid? GradeID { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [SugarColumn(ColumnDescription = "是否启用", CreateTableFieldSort = 80)]
        public bool IsEnable { get; set; }

        

        //*************************************导航*************************************

        /// <summary>
        /// 所属年级信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(GradeID), nameof(Grade.Id))]
        public Grade? GradeData { get; set; }

        /// <summary>
        /// 班主任信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(TeacherId), nameof(Teacher.Id))]
        public Teacher? TeacherData { get; set; }


        /// <summary>
        /// 班级学生信息
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(Id), nameof(Student.ClassId))]
        public List<Student>? StudentData { get; set; }
    }
}
