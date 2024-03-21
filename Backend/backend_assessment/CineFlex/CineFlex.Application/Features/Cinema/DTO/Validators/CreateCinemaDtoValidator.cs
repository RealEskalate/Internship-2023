﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.DTO.Validators
{
    public class CreateCinemaDtoValidator:AbstractValidator<CreateCinemaDto>
    {
        public CreateCinemaDtoValidator()
        {
            Include(new ICinemaDtoValidator());
        }
        
    }
}
