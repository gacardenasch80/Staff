using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class CandidateValidations : AbstractValidator<CandidateDTO>
    {
        public CandidateValidations()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).MaximumLength(50);
        }
    }
}
