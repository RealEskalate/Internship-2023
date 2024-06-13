using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs.Validators
{
    public class UpdateTaskCheckListDtoValidator : AbstractValidator<UpdateTaskCheckListDto>
    {
        public UpdateTaskCheckListDtoValidator()
        {
            Include(new ITaskCheckListDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
