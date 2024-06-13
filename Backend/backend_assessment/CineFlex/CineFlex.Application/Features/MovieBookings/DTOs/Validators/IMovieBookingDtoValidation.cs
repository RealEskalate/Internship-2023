using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.DTOs.Validators
{
    public class IMovieBookingDtoValidator : AbstractValidator<IMovieBookingDto>
    {
        public IMovieBookingDtoValidator()
        {
            RuleFor(m => m.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(m => m.CinemaId)
               .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(m => m.MovieId)
               .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(m => m.SeatId)
               .NotNull().WithMessage("{PropertyName} is required.");


        }
    }
}
