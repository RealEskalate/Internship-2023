using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.DTOs.Validators
{
    public class Update_IndexDtoValidator : AbstractValidator<_IndexDto>
    {
        public Update_IndexDtoValidator()
        {
            Include(new I_IndexDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
