using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateTeacherRequest : IValidatableObject
    {
        /// <summary>
        /// 工号
        /// </summary>
        [DisplayName("工号")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? TeacherCode { get; set; }

        /// <summary>
        /// 教师姓名
        /// </summary>
        [DisplayName("教师姓名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? TeacherName { get; set; }

        /// <summary>
        /// 教师电话
        /// </summary>
        [DisplayName("教师电话")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? TeacherPhone { get; set; }

        /// <summary>
        /// 教师邮箱
        /// </summary>
        [DisplayName("教师邮箱")]
        [MaxLength(50, ErrorMessage = "长度不能超过{0}!")]
        public string? TeacherEmail { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [DisplayName("入职时间")]
        public DateTime? TeacherInDate { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        [DisplayName("离职时间")]
        public DateTime? TeacherOutDate { get; set; }

        /// <summary>
        /// 所属年级ID
        /// </summary>
        [DisplayName("所属年级ID")]
        public Guid? GradeID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
        }

        
    }
    public class TeacherResponse : OutputKey<Guid>
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string? TeacherCode { get; set; }

        /// <summary>
        /// 教师姓名
        /// </summary>
        public string? TeacherName { get; set; }

        /// <summary>
        /// 教师电话
        /// </summary>
        public string? TeacherPhone { get; set; }

        /// <summary>
        /// 教师邮箱
        /// </summary>
        public string? TeacherEmail { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? TeacherInDate { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime? TeacherOutDate { get; set; }

        /// <summary>
        /// 所属年级ID
        /// </summary>
        public Guid? GradeID { get; set; }

        //*************************************导航*************************************
        /// <summary>
        /// 年级信息导航，多对一
        /// </summary>
        public GradeResponse? GradeData { get; set; }
    }

    public class TeacherPageListRequest : PageListInput
    {

    }
}
