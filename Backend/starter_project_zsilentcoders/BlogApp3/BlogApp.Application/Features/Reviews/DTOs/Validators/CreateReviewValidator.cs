

using FluentValidation;

namespace BlogApp.Application.Features.Reviews.DTOs.Validators
{
    public class CreateReviewValidator: AbstractValidator<ReviewDto>
    {
        public CreateReviewValidator()
        {
            Include(new IReviewValidator());
        }
    }
}
