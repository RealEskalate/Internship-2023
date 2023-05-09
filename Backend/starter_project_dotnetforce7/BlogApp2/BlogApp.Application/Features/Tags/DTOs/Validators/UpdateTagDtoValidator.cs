using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Application.Features.Tags.DTOs.Validators
{
    public class UpdateTagDtoValidator : AbstractValidator<TagDto>
    {
        public UpdateTagDtoValidator()
        {
            Include(new ITagDtoValidator());
            RuleFor(a => a.Id)
            .NotNull()
            .WithMessage("{PropertyName} must be present");

        }
    }
}