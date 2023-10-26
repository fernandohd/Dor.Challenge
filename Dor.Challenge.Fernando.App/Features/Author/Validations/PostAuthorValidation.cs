using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Author.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Author.Validations
{
    public class PostAuthorValidation : CustomAbstractValidator<PostAuthorRequest>
    {
        public PostAuthorValidation()
        {
            RuleFor(r => r.Body).NotNull();
            RuleFor(r => r.Body!.Name).NotNull().MinimumLength(1);
        }
    }
}
