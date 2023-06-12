using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs.Validators
{
    public class CreateTaskCheckListDtoValidator : AbstractValidator<CreateTaskCheckListDto>
    {
        public CreateTaskCheckListDtoValidator()
        {
            Include(new ITaskCheckListDtoValidator());
        }
    }
}
