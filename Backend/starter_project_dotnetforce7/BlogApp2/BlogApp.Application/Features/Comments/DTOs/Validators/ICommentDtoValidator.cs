

using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.DTOs.Validators
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        public ICommentDtoValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


        }
    }
}
