using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.DTOs.Validators
{
    public class updateTagDtoValidator : AbstractValidator<updateTagDto>
    {
        public updateTagDtoValidator()
        {
            Include(new ITagDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
