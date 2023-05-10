using BlogApp.Application.Contracts.Persistence;
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

             RuleFor(p => p.RateNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must not exceed {ComparisonValue}.");

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
