using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class LanguageLevelValidations : AbstractValidator<LanguageLevelDTO>
    {
        public LanguageLevelValidations()
        {
            RuleFor(x => x.LanguageLevelName).NotEmpty();
            RuleFor(x => x.LanguageLevelName).MaximumLength(50);
        }
    }
}
