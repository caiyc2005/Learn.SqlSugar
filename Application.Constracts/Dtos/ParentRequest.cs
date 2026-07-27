using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Constracts.Dtos
{
    public class CreateOrUpdateParentRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return [];
            //throw new NotImplementedException();
        }

        public class SchoolResponse
        {


        }

        public class SchoolPageListRequest
        {

        }
    }
}
