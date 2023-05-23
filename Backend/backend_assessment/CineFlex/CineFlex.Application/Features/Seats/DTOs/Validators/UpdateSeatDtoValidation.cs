﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatDtoValidation: AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidation()
        {
            Include(new ISeatDtoValidation());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
