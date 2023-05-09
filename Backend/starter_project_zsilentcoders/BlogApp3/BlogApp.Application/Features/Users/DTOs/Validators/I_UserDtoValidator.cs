using BlogApp.Application.Features.Users.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.DTOs.Validators
{
    public class I_UserDtoValidator : AbstractValidator<I_UserDto>
    {
        public I_UserDtoValidator()
        {
        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(2, 50).WithMessage("{PropertyName} must be between 2 and 50 characters.");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(2, 50).WithMessage("{PropertyName} must be between 2 and 50 characters.");
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} is not valid.");
        }
    }
}
