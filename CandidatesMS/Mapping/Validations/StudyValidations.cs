using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Mapping.Validations
{
    public class StudyValidations : AbstractValidator<StudyDTO>
    {
        public StudyValidations()
        {
            RuleFor(x => x.CandidateId).NotEmpty();
            RuleFor(x => x.CandidateId).NotNull();
        }
    }
}
