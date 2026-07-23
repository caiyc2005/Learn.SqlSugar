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
    /// 创建、更新班级信息
    /// </summary>
    public class CreateOrUpdateClassRequest : IValidatableObject
    {
        /// <summary>
        /// 班级编码
        /// </summary>
        [DisplayName("班级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? ClassCode { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [DisplayName("班级名称")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? ClassName { get; set; }

        /// <summary>
        /// 班主任ID
        /// </summary>
        [DisplayName("班主任ID")]
        //[Required(ErrorMessage = "{0}必填")]
        [MaxLength(50, ErrorMessage = "{0}长度不能超过{1}!")]
        public Guid? TeacherId { get; set; }

        /// <summary>
        /// 班主任姓名
        /// </summary>
        [DisplayName("班主任姓名")]
        //[Required(ErrorMessage = "{0}必填")]
        [MaxLength(30, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? TeacherName { get; set; }

        /// <summary>
        /// 班级人数
        /// </summary>
        [DisplayName("班级人数")]
        [Required(ErrorMessage = "{0}必填")]
        public int SumNum { get; set; } = 0;

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        [Required(ErrorMessage = "{0}必填")]
        public bool IsEnable { get; set; }


        /// <summary>
        /// 自定义参数验证
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
        }
    }

    /// <summary>
    /// 班级信息
    /// </summary>
    public class ClassResponse : OutputKey<Guid>
    // : OutPut<> // 只有业务字段
    // : OutputKey<> // 业务字段 + ID
    // : OutputWithCreated<Guid> // 业务字段 + ID + 创建时间
    // : OutputWithUpdated<> //业务字段 + ID + 创建时间 + 更新时间

    {
        /// <summary>
        /// 班级编码
        /// </summary>
        public string? ClassCode { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string? ClassName { get; set; }
        /// <summary>
        /// 班主任姓名
        /// </summary>
        public string? TeacherName { get; set; }
        /// <summary>
        /// 班级人数
        /// </summary>
        public int SumNum { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
    }

    /// <summary>
    /// 分页
    /// </summary>
    public class ClassPageListRequest : PageListInput
    {

    }
}
