using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.DTOs.Validators
{
    public class UpdateCheckListDtoValidator : AbstractValidator<UpdateCheckListDto>
    {
        public UpdateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
