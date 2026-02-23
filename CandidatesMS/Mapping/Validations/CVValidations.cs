using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping.Validations
{
    public class CVValidations : AbstractValidator<CVDTO>
    {
        public CVValidations()
        {
            RuleFor(x => x.CandidateId).NotEmpty();
        }
    }
}
