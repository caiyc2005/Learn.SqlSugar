using Domain.Shared.Enums;
using SqlSugar;
using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateStudentRequest : IValidatableObject
    {

        /// <summary>
        /// 学号
        /// </summary>
        [DisplayName("学生学号")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? StudentCode { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [DisplayName("学生学号")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? StudentName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        [DisplayName("班级ID")]
        //[Required(ErrorMessage = "{0}必填")]
        //[MaxLength(50, ErrorMessage = "{0}长度不能超过{1}!")]
        public Guid? ClassId { get; set; }

        /// <summary>
        /// 学生类型
        /// </summary>
        [DisplayName("学生类型")]
        [Required(ErrorMessage = "{0}必填")]
        public StuTypeEnum StuType { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
        }
    }

    public class StudentResponse : OutputKey<Guid>
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string? StudentCode { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string? StudentName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid? ClassId { get; set; }

        /// <summary>
        /// 学生类型
        /// </summary>
        public StuTypeEnum StuType { get; set; }

        //*************************************导航*************************************

        /// <summary>
        /// 班级信息
        /// </summary>
        public ClassResponse? ClassData { get; set; }

        /// <summary>
        /// 家长信息，一对多
        /// </summary>
        public List<ParentResponse> ParentList { get; set; }

    }

    public class StudentPageListRequest : PageListInput
    {

    }

}
