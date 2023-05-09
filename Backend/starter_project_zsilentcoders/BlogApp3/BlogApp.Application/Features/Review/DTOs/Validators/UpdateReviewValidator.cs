using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Review.DTOs.Validators
{
    public class UpdateReviewValidator: AbstractValidator<ReviewDto>
    {
        public UpdateReviewValidator(IUnitOfWork unitOfWork)
        {
            Include(new IReviewValidator());
            RuleFor(p => p.Id)
            .MustAsync(async (id, token) => await unitOfWork.BlogRepository.Exists(id)).WithMessage($"Blog not found");
        }
    }
}
