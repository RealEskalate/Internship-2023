using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CineFlex.Application.Features.Posts.DTOs.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            
            RuleFor(p=>p.Title)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present")
            .MaximumLength(50)
            .WithMessage("{PropertyName} length should be less than {PropertyValue}");
            RuleFor(p=>p.Content)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present")
            .MaximumLength(500)
            .WithMessage("{PropertyName} length should be less than {PropertyValue}");
            RuleFor(p=>p.UserId)
            .NotNull()
            .WithMessage("{ProperyName} is required")
            .NotEmpty()
            .WithMessage("{PropertyName} must be present");


        }
    }
}