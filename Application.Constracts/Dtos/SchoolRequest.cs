using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    /// <summary>
    /// 新建、修改学校信息
    /// </summary>
    public class CreateOrUpdateSchoolRequest : IValidatableObject
    {
        /// <summary>
        /// 学校编码
        /// </summary>
        [DisplayName("学校编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolCode { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [DisplayName("学校名称")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(100, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolName { get; set; }

        /// <summary>
        /// 学校Logo
        /// </summary>
        [DisplayName("学校Logo")]
        public string? SchoolLogo { get; set; }

        /// <summary>
        /// 学校校长姓名
        /// </summary>
        [DisplayName("学校名称")]
        [MaxLength(100, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolManager { get; set; }

        /// <summary>
        /// 学校地址
        /// </summary>
        [DisplayName("学校地址")]
        [MaxLength(100, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolAddress { get; set; }

        /// <summary>
        /// 学校简介
        /// </summary>
        [DisplayName("学校简介")]
        [MaxLength(500, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolDescription { get; set; }

        /// <summary>
        /// 学校创建时间
        /// </summary>
        [DisplayName("学校创建时间")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 学校校长最新换届时间
        /// </summary>
        [DisplayName("学校校长最新换届时间")]
        public DateTime? ManagerUpdateDate { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 学校信息
    /// </summary>
    public class SchoolResponse : OutputKey<Guid>
    {
        /// <summary>
        /// 学校编码
        /// </summary>
        public string? SchoolCode { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string? SchoolName { get; set; }

        /// <summary>
        /// 学校Logo
        /// </summary>
        public string? SchoolLogo { get; set; }

        /// <summary>
        /// 学校校长姓名
        /// </summary>
        public string? SchoolManager { get; set; }

        /// <summary>
        /// 学校地址
        /// </summary>
        public string? SchoolAddress { get; set; }

        /// <summary>
        /// 学校简介
        /// </summary>
        public string? SchoolDescription { get; set; }

        /// <summary>
        /// 学校创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 学校校长最新换届时间
        /// </summary>
        public DateTime? ManagerUpdateDate { get; set; }

        /// <summary>
        /// 班级列表
        /// </summary>
        public List<ClassResponse>? ClassList { get; set; }

        /// <summary>
        /// 年级列表
        /// </summary>
        public List<GradeResponse>? GradeList { get; set; }
    }

    /// <summary>
    /// 学校分页组件
    /// </summary>
    public class SchoolPageListRequest : PageListInput
    {

    }
}
