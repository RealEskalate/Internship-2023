using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Application.Features.Tags.DTOs.Validators
{
    public class ITagDtoValidator : AbstractValidator<ITagDto>
    {
        public ITagDtoValidator()
        {
            RuleFor(a => a.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must not exceed {ComparisonValue} Characters.");

            RuleFor(a => a.Description)
             .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} Characters.");
        }

    }
}