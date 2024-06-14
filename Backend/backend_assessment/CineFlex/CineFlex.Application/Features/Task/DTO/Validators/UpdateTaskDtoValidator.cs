using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Task.DTO.Validators
{
    public class UpdateTaskDtoValidator:AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());
            RuleFor(a => a.Id)
           .NotNull()
           .WithMessage("{PropertyName} must be present");

        }
    }
    }

