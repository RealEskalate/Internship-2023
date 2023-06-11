using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.DTOs.Validators
{
    public class UpdateDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(p => p.Title)
            .NotNull()
            .WithMessage("Post must have {PropertyName}")
            .NotEmpty()
            .WithMessage("Post need to have {ProperyName}")
            .MaximumLength(50)
            .WithMessage("{PropertyName} length should be less than {PropertyValue}");
            RuleFor(p => p.Content)
            .NotNull()
            .WithMessage("Post must have {PropertyName}")
            .NotEmpty()
            .WithMessage("Post need to have {PropertyName}")
            .MaximumLength(500)
            .WithMessage("{PropertyName} length is less than {PropertyValue}");

        }
    }
}
