using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using FluentValidation;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators;

public class DeleteBlogRateDtoValidator : AbstractValidator<DeleteBlogRateDto>
{
    

    public DeleteBlogRateDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.BlogId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.BlogRateRepository.BlogExists(id)).WithMessage($"Blog not found");
        RuleFor(p => p.RaterId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.BlogRateRepository.RaterExists(id)).WithMessage($"Blo not found");
    }
}