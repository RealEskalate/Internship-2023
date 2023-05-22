using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators
{
    public class BlogRateDtoValidator : AbstractValidator<BlogRateDto>
    {
        public BlogRateDtoValidator(IUnitOfWork unitOfWork) {
            Include(new IBlogRateDtoValidator());
            
            RuleFor(p => p.BlogId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.BlogRateRepository.BlogExists(id)).WithMessage($"Blog not found");
            RuleFor(p => p.RaterId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.BlogRateRepository.RaterExists(id)).WithMessage($"Rater not found");
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} should not be null");
        }
    }
}
