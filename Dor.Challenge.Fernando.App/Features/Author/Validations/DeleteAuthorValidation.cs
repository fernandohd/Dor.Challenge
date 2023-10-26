using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Author.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Author.Validations
{
    public class DeleteAuthorValidation : CustomAbstractValidator<DeleteAuthorRequest>
    {
        public DeleteAuthorValidation()
        {
            RuleFor(r => r.ID).GreaterThan(0);
        }
    }
}
