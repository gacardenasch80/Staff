using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class LanguageValidations : AbstractValidator<LanguageDTO>
    {
        public LanguageValidations()
        {
            RuleFor(x => x.LanguageName).NotEmpty();
            RuleFor(x => x.LanguageName).MaximumLength(50);
        }
    }
}
