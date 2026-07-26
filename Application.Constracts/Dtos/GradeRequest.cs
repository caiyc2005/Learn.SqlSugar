using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateGradeRequest : IValidatableObject
    {

        /// <summary>
        /// 年级编码
        /// </summary>
        [DisplayName("年级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? GradeCode { get; set; }

        /// <summary>
        /// 年级负责人ID列表
        /// </summary>
        [DisplayName("年级负责人")]
        //[Required(ErrorMessage = "{0}必填")]
        public List<string>? GradeManagers { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        [DisplayName("学校ID")]
        [Required(ErrorMessage = "{0}必填")]
        //[MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? SchoolId { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }
    }

    public class GradeResponse : OutputKey<Guid>
    {
        /// <summary>
        /// 年级编码
        /// </summary>
        public string? GradeCode { get; set; }

        /// <summary>
        /// 年级负责人ID列表
        /// </summary>
        public List<string>? GradeManagers { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        //public string? SchoolId { get; set; }//取消返回学校ID，在学校的信息里面会返回带有学校ID字段的数据信息



        /// <summary>
        /// 学校信息
        /// </summary>
        public SchoolResponse? SchoolData { get; set; }

        /// <summary>
        /// 年级负责人信息
        /// </summary>
        //public Teacher? TeacherData { get; set; }

        /// <summary>
        /// 班级信息
        /// </summary>
 
        public List<ClassResponse>? ClassList { get; set; }
    }

    public class GradePageListRequest : PageListInput
    {
        /// <summary>
        /// 学校编码
        /// </summary>
        public string? SchoolCode { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string? ClassName { get; set; }
    }
}
