using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Review.DTOs.Validators
{
    public class IReviewValidator: AbstractValidator<ReviewDto>
    {
        public IReviewValidator()
        {
            RuleFor(p => p.Comment)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} should not exceed 500.");
            RuleFor(p => p.BlogId)
                .NotNull().WithMessage("{PropertyName} should not be null.");
            RuleFor(p => p.ReviewerId)
                .NotNull().WithMessage("{PropertyName} should not be null.");
        }
    }
}
