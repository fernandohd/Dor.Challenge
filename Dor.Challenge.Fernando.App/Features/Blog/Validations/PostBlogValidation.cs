using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Blog.Validations
{
    public class PostBlogValidation : CustomAbstractValidator<PostBlogRequest>
    {
        public PostBlogValidation()
        {
            RuleFor(r => r.Body).NotNull();
            RuleFor(r => r.Body!.ID).Null();
            RuleFor(r => r.Body!.Title).NotNull().MinimumLength(1);
        }
    }
}
