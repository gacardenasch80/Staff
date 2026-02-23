using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping.Validations
{
    public class WorkExperienceValidations : AbstractValidator<WorkExperienceDTO>
    {
        public WorkExperienceValidations()
        {
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.Company).NotNull();
            RuleFor(x => x.Company).MaximumLength(50);

            RuleFor(x => x.Position).NotEmpty();
            RuleFor(x => x.Position).NotNull();
            RuleFor(x => x.Position).MaximumLength(50);

            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.StartDate).NotNull();

            RuleFor(x => x.CandidateId).NotEmpty();
            RuleFor(x => x.CandidateId).NotNull();
        }
    }
}
