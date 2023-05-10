using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators
{
    public class CreateBlogRateDtoValidator : AbstractValidator<CreateBlogRateDto>
    {
        public CreateBlogRateDtoValidator()
        {
            Include(new IBlogRateDtoValidator());

        }
    }
}
