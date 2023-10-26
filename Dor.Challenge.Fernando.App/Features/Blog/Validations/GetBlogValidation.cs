using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Blog.Validations
{
    public class GetBlogValidation : CustomAbstractValidator<GetBlogRequest>
    {
        public GetBlogValidation()
        {
            RuleForEach(r => r.ID).GreaterThan(0);
        }
    }
}
