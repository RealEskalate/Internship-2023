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
        int maxBound = 10;
        int minBound = 0;
        RuleFor(p => p.Rate)
            .LessThanOrEqualTo(maxBound).WithMessage("{PropertyName} must not exceed {ComparisonValue}.")
            .GreaterThanOrEqualTo(minBound).WithMessage("{PropertyName} must equal or exceed {ComparisonValue}.");
    }
}
