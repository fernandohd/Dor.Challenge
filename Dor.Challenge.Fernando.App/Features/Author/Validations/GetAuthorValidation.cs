using Dor.Challenge.Fernando.App.Common.Validation;
using Dor.Challenge.Fernando.App.Features.Author.Requests;
using FluentValidation;

namespace Dor.Challenge.Fernando.App.Features.Author.Validations
{
    public class GetAuthorValidation : CustomAbstractValidator<GetAuthorRequest>
    {
        public GetAuthorValidation()
        {
            RuleForEach(r => r.ID).GreaterThan(0);
        }
    }
}
