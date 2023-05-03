using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Ratings.DTOs.Validators;
public class RatingDtoValidator : AbstractValidator<RatingDto>
{
    public RatingDtoValidator()
    {
        int maxRate = 10;
        int minRate = 0;
        RuleFor(p => p.Rate)
            .GreaterThan(maxRate).WithMessage("{PropertyName} must not exceed {ComparisonValue}.")
            .GreaterThan(minRate).WithMessage("{PropertyName} must exceed {ComparisonValue}.");
    }
}
