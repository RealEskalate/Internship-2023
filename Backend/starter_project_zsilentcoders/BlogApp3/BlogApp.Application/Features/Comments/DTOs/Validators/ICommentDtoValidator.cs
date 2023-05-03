

using BlogApp.Application.Features.Comments.DTOs;
using FluentValidation;

namespace BlogApp.Application.Features.Comments.DTOs.Validators;

 public class ICommentDtoValidator : AbstractValidator<ICommentDto>
{
  
 
    public ICommentDtoValidator()
    {
        RuleFor(p => p.CommenterId)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull();
       
        RuleFor(p => p.Content)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull()
        .Length(2, 100);

        RuleFor(p => p.BlogId)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull();
}
}

