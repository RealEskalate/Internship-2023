using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.DTO.Validators
{
    public class ICinemaDtoValidator:AbstractValidator<ICinemaDto>
    {
        public ICinemaDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Location)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(400).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


            RuleFor(p => p.ContactInformation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(400).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
    }
    }

