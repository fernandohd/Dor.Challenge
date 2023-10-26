using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Author.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Author.Validations
{
    public class PutAuthorValidation : CustomAbstractValidator<PutAuthorRequest>
    {
        public PutAuthorValidation()
        {
            RuleFor(r => r.Body).NotNull();
            RuleFor(r => r.Body!.ID).NotNull().GreaterThan(0);
            RuleFor(r => r.Body!.Name).NotNull().MinimumLength(1);
        }
    }
}
