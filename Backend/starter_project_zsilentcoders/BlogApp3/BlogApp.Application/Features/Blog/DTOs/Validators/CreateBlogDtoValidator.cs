using BlogApp.Application.Features.Blog.DTOs;
using FluentValidation;

namespace Application.DTOs.Blog.Validators;

public class CreateBlogDtoValidator: AbstractValidator<CreateBlogDto>
{
    public CreateBlogDtoValidator()
    {
        RuleFor(p => p.Title).MinimumLength(1).WithMessage("Title cannot be empty");
        RuleFor(p => p.Content).MinimumLength(1).WithMessage("Content cannot be empty");
    }
}