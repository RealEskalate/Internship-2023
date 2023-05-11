using FluentValidation;

namespace BlogApp.Application.Features.Reviews.DTOs.Validators;

public class UpdateReviewValidator :AbstractValidator<UpdateReviewDto>
{
    public UpdateReviewValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("{PropertyName} is required ")
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