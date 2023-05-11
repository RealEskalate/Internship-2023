using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.DTO.Validators
{
    public class ConfirmEmailDtoValidator : AbstractValidator<ConfirmEmailDto>
    {
        public ConfirmEmailDtoValidator()
        {
            RuleFor(p => p.Token)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Matches(@"^[a-zA-Z0-9-]*$");

            RuleFor(p => p.UserId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
                


        }
    }
}
