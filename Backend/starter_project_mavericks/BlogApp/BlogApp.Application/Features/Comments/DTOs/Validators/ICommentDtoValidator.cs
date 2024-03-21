using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.DTOs.Validators
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        public ICommentDtoValidator()
        {
            RuleFor(p => p.Commenter)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
         RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        RuleFor(p => p.BlogId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
