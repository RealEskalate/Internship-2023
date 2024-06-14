using CineFlex.Application.Features.Seat.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.DTO.Validators
{
    public class ISeatDtoValidator:AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(p => p.SeatType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
                

            RuleFor(p => p.Available)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();


            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0" );

        }
    }
    }

