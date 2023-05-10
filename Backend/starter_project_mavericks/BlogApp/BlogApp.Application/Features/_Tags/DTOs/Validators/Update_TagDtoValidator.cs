using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs.Validators
{
    public class Update_TagDtoValidator : AbstractValidator<Update_TagDto>
    {
        public Update_TagDtoValidator()
        {
            Include(new I_TagDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
