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
        [SugarColumn(ColumnDescription = "学生学号", Length = 20, CreateTableFieldSort = 10)]
        [DisplayName("班级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? StudentCode { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "学生姓名", Length = 20, CreateTableFieldSort = 20)]
        [DisplayName("班级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public string? StudentName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        [SugarColumn(ColumnDescription = "班级ID", Length = 50, CreateTableFieldSort = 30)]
        [DisplayName("班级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
        public Guid? ClassId { get; set; }

        /// <summary>
        /// 学生类型
        /// </summary>
        [SugarColumn(ColumnDescription = "学生类型", Length = 50, CreateTableFieldSort = 50)]
        [DisplayName("班级编码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}!")]
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
