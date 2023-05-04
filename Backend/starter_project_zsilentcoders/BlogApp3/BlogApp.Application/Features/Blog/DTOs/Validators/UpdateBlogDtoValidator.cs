using BlogApp.Application.Features.Blog.DTOs;
using FluentValidation;

namespace Application.DTOs.Blog.Validators;

public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDto>
{
    public UpdateBlogDtoValidator()
    {
    
    }
    
}