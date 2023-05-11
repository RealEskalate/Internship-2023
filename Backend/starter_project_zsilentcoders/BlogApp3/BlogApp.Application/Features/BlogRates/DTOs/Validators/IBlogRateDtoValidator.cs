using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators
{
    public class IBlogRateDtoValidator : AbstractValidator<IBlogRateDto>
    {
        public IBlogRateDtoValidator() {
            RuleFor(p => p.RaterId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var raterExists = true;
                return !raterExists;
            }).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.BlogId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var blogExists = true;
                return !blogExists;
            }).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.RateNo).NotNull().WithMessage("{PropertyName} must not be null");

        }
    }
}
