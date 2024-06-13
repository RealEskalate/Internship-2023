using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs.Validators
{
    public class ITaskCheckListDtoValidator : AbstractValidator<ITaskCheckListDto>
    {
        public ITaskCheckListDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(m => m.isComplete)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

        }
    }
}
