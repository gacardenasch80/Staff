using CandidatesMS.Models;
using FluentValidation;

namespace CandidatesMS.Mapping.Validations
{
    public class BasicInformationValidations : AbstractValidator<BasicInformationDTO>
    {
        public BasicInformationValidations()
        {
            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Name).NotNull();
            //RuleFor(x => x.Name).MaximumLength(50);

            //RuleFor(x => x.Surname).NotEmpty();
            //RuleFor(x => x.Surname).NotNull();
            //RuleFor(x => x.Surname).MaximumLength(50);

            //RuleFor(x => x.Document).NotEmpty();
            //RuleFor(x => x.Document).NotNull();

            //RuleFor(x => x.DocumentTypeId).NotEmpty();
            //RuleFor(x => x.DocumentTypeId).NotNull();

            //RuleFor(x => x.Country).NotEmpty();
            //RuleFor(x => x.Country).NotNull();
            //RuleFor(x => x.State).NotEmpty();
            //RuleFor(x => x.State).NotNull();
            //RuleFor(x => x.City).NotEmpty();
            //RuleFor(x => x.City).NotNull();

            //RuleFor(x => x.Phone).MaximumLength(50);

            //RuleFor(x => x.Cellphone).NotEmpty();
            //RuleFor(x => x.Cellphone).NotNull();
            //RuleFor(x => x.Cellphone).MaximumLength(50);

            //RuleFor(x => x.LinkedInURL).MaximumLength(250);
            //RuleFor(x => x.FacebookURL).MaximumLength(250);
            //RuleFor(x => x.TwitterURL).MaximumLength(250);
            //RuleFor(x => x.GitHubURL).MaximumLength(250);
            //RuleFor(x => x.BitBucketURL).MaximumLength(250);
        }
    }
}
