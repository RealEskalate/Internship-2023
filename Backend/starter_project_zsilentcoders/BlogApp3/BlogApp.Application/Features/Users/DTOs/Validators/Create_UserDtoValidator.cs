using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Features.Users.DTOs.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.DTOs.Validators
{
    public class Create_UserDtoValidator : AbstractValidator<Create_UserDto>
    {
        public Create_UserDtoValidator()
        {
            Include(new I_UserDtoValidator());
        }
    }

}
