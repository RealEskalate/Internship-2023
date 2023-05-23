﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class CreateSeatsDtoValidator : AbstractValidator<CreateSeatsDto>
    {
        public CreateSeatsDtoValidator()
        {
            Include(new ISeatsDtoValidator());
        }
    }
}
