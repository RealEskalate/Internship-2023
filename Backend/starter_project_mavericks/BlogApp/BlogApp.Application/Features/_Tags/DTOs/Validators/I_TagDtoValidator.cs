using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs.Validators
{
    public class I_TagDtoValidator : AbstractValidator<I_TagDto>
    {
        public I_TagDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(2000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
