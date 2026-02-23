using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping
{
    public class VideoValidations : AbstractValidator<VideoDTO>
    {
        public VideoValidations()
        {
            //RuleFor(x => x.IsUrl).NotEmpty();
            RuleFor(x => x.CandidateId).NotEmpty();
        }
    }
}
