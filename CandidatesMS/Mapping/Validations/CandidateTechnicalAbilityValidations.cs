using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class CandidateTechnicalAbilityValidations : AbstractValidator<Candidate_TechnicalAbilityDTO>
    {
        public CandidateTechnicalAbilityValidations()
        {
            RuleFor(x => x.CandidateId).NotEmpty();
        }
    }
}
