using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators
{
    public class BlogRateDtoValidator : AbstractValidator<BlogRateDto>
    {
        public BlogRateDtoValidator() {
            Include(new IBlogRateDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} should not be null");
        }
    }
}
