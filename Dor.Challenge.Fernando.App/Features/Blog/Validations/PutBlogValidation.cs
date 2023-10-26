using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Blog.Validations
{
    public class PutBlogValidation : CustomAbstractValidator<PutBlogRequest>
    {
        public PutBlogValidation()
        {
            RuleFor(r => r.Body).NotNull();
            RuleFor(r => r.Body!.ID).NotNull().GreaterThan(0);
            RuleFor(r => r.Body!.Title).NotNull().MinimumLength(1);
        }
    }
}
