using FluentValidation;
using CandidatesMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Mapping.Validations
{
    public class AttachedFileValidations : AbstractValidator<AttachedFileDTO>
    {
        public AttachedFileValidations()
        {
            RuleFor(x => x.CandidateId).NotEmpty();
            RuleFor(x => x.CandidateId).NotNull();
        }
    }
}
