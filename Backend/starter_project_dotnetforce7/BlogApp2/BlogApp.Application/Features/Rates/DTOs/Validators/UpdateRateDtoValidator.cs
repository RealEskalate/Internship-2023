using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Rates.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs.Validators
{
    public class UpdateRateDtoValidator : AbstractValidator<UpdateRateDto>
    {
        public UpdateRateDtoValidator()
        {
            Include(new IRateDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
