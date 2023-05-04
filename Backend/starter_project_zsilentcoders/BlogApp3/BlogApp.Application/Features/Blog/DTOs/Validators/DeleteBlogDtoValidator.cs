using BlogApp.Application.Contracts.Persistence;
using FluentValidation;

namespace BlogApp.Application.Features.Blog.DTOs.Validators;

public class DeleteBlogDtoValidator: AbstractValidator<DeleteBlogDto>
{
    private IBlogRepository _blogRepository;

    public DeleteBlogDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.BlogRepository.Exists(id)).WithMessage($"Blog not found");
    }
}