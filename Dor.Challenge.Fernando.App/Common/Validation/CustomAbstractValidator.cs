using Dor.Challenge.Fernando.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Dor.Challenge.Fernando.App.Common.Validation
{
    public abstract class CustomAbstractValidator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var validationResult = base.Validate(context);

            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.First();

                throw new BadRequestApiException(error.ErrorMessage, filePath: context.InstanceToValidate?.ToString());
            }

            return validationResult;
        }
    }
}
