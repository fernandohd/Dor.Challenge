using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Blog.Validations
{
    public class DeleteBlogValidation : CustomAbstractValidator<DeleteBlogRequest>
    {
        public DeleteBlogValidation()
        {
            RuleFor(r => r.ID).GreaterThan(0);
        }
    }
}
