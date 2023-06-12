using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.DTOs.Validators
{
    public class ICheckListDtoValidator : AbstractValidator<ICheckListDto>
    {
        public ICheckListDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

     

        }
    }
}

