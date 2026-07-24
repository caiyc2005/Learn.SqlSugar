using SqlSugarCoreExtra.Furion.Component.ServiceExts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateSchoolRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }
    }

    public class SchoolResponse : OutputKey<Guid>
    {

    }

    public class SchoolPageListRequest : PageListInput
    {

    }
}
