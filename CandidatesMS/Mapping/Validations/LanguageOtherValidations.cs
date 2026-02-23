using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class LanguageOtherValidations : AbstractValidator<LanguageOtherDTO>
    {
        public LanguageOtherValidations()
        {
            RuleFor(x => x.LanguageOtherName).NotEmpty();
            RuleFor(x => x.LanguageOtherName).MaximumLength(50);
        }
    }
}
