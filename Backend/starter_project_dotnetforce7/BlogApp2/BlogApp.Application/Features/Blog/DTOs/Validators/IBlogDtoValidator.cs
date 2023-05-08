using BlogApp.Application.Features.Blogs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators

{
    public class IBlogDtoValidator : AbstractValidator<IBlogDto>
    {
        public IBlogDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

             RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(400).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


             RuleFor(p => p.PublicationStatus)
                .Must(x => (x == false || x == true))
                .WithMessage("{PropertyName} is required.");
        }
    }
}
