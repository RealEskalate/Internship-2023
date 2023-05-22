using FluentValidation;

namespace BlogApp.Application.Features.Reviews.DTOs.Validators;

public class IReviewDtoValidator : AbstractValidator<IReviewDto>
{
    public IReviewDtoValidator()
    {
        RuleFor(p => p.BlogId)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present");

        RuleFor(p => p.ReviewerId)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present");
        RuleFor(p => p.Comment)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present")
            .MaximumLength(5000);
    }
}