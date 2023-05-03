using BlogApp.Application.Contracts.Persistence;
using FluentValidation;

namespace BlogApp.Application.Features.Blog.DTOs.Validators;

public class DeleteBlogDtoValidator: AbstractValidator<DeleteBlogDto>
{
    private IBlogRepository _blogRepository;

    public DeleteBlogDtoValidator(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;

        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await _blogRepository.Exists(id));
    }
}