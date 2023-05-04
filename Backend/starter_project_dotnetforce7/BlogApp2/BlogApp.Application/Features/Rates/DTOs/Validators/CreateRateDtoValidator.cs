using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs.Validators
{
    public class CreateRateDtoValidator : AbstractValidator<CreateRateDto>
    {
        public CreateRateDtoValidator()
        {
            Include(new IRateDtoValidator());
        }
    }

}
