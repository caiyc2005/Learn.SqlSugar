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
        // 该字段疑似不需要，可以通过导航属性获取年级负责人信息，实际场景建议删除该字段（Teacher表里存有所属年级数据）
        [SugarColumn(ColumnDescription = "年级负责人", CreateTableFieldSort = 20)]
        public List<string>? GradeManagers { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        [SugarColumn(ColumnDescription = "学校ID", CreateTableFieldSort = 30)]
        public Guid? SchoolId { get; set; } // 注意字段类型匹配！

        //*************************************导航*************************************

        /// <summary>
        /// 学校信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(SchoolId),nameof(School.Id))]
        public School? SchoolData { get; set; }
        //年级对学校是多对一，具体方法与一对一的使用方法一致。


        /// <summary>
        /// 年级负责人信息，一对多
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(Teacher.GradeID))]//通过本表的主键，关联是从表的xx字段
        public List<Teacher>? TeacherList { get; set; }

        /// <summary>
        /// 班级信息
        /// </summary>
        [Navigate(NavigateType.OneToMany,  nameof(Class.GradeID))]
        public List<Class>? ClassList { get; set; }
    }
}
