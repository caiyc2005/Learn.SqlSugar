using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateParentRequest : IValidatableObject
    {

        /// <summary>
        /// 家长编码
        /// </summary>
        [DisplayName("家长编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? ParentCode { get; set; }

        /// <summary>
        /// 家长姓名
        /// </summary>
        [DisplayName("家长姓名")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? ParentName { get; set; }

        /// <summary>
        /// 家长联系方式
        /// </summary>
        [DisplayName("家长联系方式")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? ParentPhone { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        [DisplayName("学生ID")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(50, ErrorMessage = "{0}长度不能超过{1}!")]
        public Guid? StudentId { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 学生信息
        /// </summary>
        //多对一
        [Navigate(NavigateType.OneToOne, nameof(StudentId))]
        public StudentResponse? StudentData { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }

        
    }
    public class ParentResponse : OutputKey<Guid>
    {
        /// <summary>
        /// 家长编码
        /// </summary>
        public string? ParentCode { get; set; }

        /// <summary>
        /// 家长姓名
        /// </summary>
        public string? ParentName { get; set; }

        /// <summary>
        /// 家长联系方式
        /// </summary>
        public string? ParentPhone { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        public Guid? StudentId { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 学生信息
        /// </summary>
        //多对一
        public StudentResponse? StudentData { get; set; }
    }

    public class ParentPageListRequest : PageListInput
    {

    }
}
