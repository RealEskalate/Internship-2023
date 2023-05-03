using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Features.Comments.DTOs;

using FluentValidation;
namespace BlogApp.Application.Features.Comments.DTOs.Validators;


public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator()
    {
        Include(new ICommentDtoValidator());
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present"); 
    }
}
