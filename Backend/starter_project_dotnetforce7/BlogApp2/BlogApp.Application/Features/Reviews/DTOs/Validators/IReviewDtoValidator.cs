using FluentValidation;


namespace BlogApp.Application.Features.Reviews.DTOs.Validators
{
    public class IReviewDtoValidator : AbstractValidator<IReviewDto>
    {
        public IReviewDtoValidator()
        {

            RuleFor(p => p.ReviewerId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

            RuleFor(p => p.ReviewContent)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull() 
            .MaximumLength(400).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.BlogId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

            RuleFor(p => p.isResolved)
            .Must(x => x == false || x == true) 
            .WithMessage("{PropertyName} is required.");
        }
    }
}

