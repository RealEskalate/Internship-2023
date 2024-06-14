using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.DTOs.Validators
{
    public class CreateCheckListDtoValidator : AbstractValidator<CreateCheckListDto>
    {
        public CreateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());
        }
    }
}
