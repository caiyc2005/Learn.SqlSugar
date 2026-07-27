using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateStudentRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
        }
    }

    public class StudentResponse
    {


    }

    public class StudentPageListRequest : PageListInput
    {

    }

}
