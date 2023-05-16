using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.DTO.Validators
{
    public class SignInFormDtoValidators : AbstractValidator<SigninFormDto>
    {
        public SignInFormDtoValidators()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("{PropertyName} must be 8 to 15 characters long and contain at least one uppercase letter, one lowercase letter, one numeric digit, and one special character.")
                .NotNull();
        }
    }
}
