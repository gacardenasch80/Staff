using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class DescriptionValidations : AbstractValidator<Description>
    {
        public DescriptionValidations()
        {
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Text).NotNull();
            RuleFor(x => x.Text).MaximumLength(500);
        }
    }
}
