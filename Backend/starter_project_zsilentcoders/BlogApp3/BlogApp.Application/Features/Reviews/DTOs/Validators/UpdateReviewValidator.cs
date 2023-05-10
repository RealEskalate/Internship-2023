using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.DTOs.Validators
{
    public class UpdateReviewValidator: AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Comment)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} should not exceed 500.");
            RuleFor(p => p.ReviewerId)
                .NotNull().WithMessage("{PropertyName} should not be null.");
            RuleFor(p => p.Id)
            .MustAsync(async (id, token) => await unitOfWork.ReviewRepository.Exists(id)).WithMessage($"Blog not found");
        }
    }
}
