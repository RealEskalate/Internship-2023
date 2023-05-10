using FluentValidation;

namespace BlogApp.Application.Features.Reviews.DTOs.Validators;

public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
{
    public CreateReviewDtoValidator()
    {
        Include(new IReviewDtoValidator());
    }
}