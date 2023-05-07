

using FluentValidation;

namespace BlogApp.Application.Features.Review.DTOs.Validators
{
    public class CreateReviewValidator: AbstractValidator<ReviewDto>
    {
        public CreateReviewValidator()
        {
            Include(new IReviewValidator());
        }
    }
}
