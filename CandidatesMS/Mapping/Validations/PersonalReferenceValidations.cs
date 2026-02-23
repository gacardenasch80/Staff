using CandidatesMS.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Mapping.Validations
{
    public class PersonalReferenceValidations : AbstractValidator<PersonalReferenceDTO>
    {
        public PersonalReferenceValidations()
        {
            RuleFor(x => x.ReferenceName).MaximumLength(50);
         
            RuleFor(x => x.ReferenceSurname).MaximumLength(50);
          
            RuleFor(x => x.PhoneNumber).MaximumLength(50);                       
        }
    }
}
