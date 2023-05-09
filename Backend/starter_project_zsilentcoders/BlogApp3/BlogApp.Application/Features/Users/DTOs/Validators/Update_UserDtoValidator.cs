using BlogApp.Application.Features.Users.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.DTOs.Validators
{
    public class Update_UserDtoValidator : AbstractValidator<Update_UserDto>
    {
        public Update_UserDtoValidator()
        {
            Include(new I_UserDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
