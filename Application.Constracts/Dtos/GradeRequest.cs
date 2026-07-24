using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateGradeRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }
    }

    public class GradeResponse : OutputKey<Guid>
    {

    }

    public class GradePageListRequest : PageListInput
    {

    }
}
