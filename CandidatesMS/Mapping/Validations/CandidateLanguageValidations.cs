using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class CandidateLanguageValidations : AbstractValidator<Candidate_LanguageDTO>
    {
        public CandidateLanguageValidations()
        {
            //RuleFor(x => x.Candidate_LanguageId).NotEmpty();
            RuleFor(x => x.CandidateId).NotEmpty();
            //RuleFor(x => x.LanguageId).NotEmpty();
            //RuleFor(x => x.LanguageLevelId).NotEmpty();
        }
    }
}
