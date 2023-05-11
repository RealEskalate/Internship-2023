
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using FluentValidation;

namespace BlogApp.Application.Features.Comments.DTOs.Validators;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator()
    {
        Include(new ICommentDtoValidator());
    }

    
}
