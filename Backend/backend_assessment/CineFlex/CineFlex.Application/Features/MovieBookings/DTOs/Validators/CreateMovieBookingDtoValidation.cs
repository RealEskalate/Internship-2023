using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.DTOs.Validators
{
    public class CreateMovieBookingDtoValidator : AbstractValidator<CreateMovieBookingDto>
    {
        public CreateMovieBookingDtoValidator()
        {
            Include(new IMovieBookingDtoValidator());
        }
    }
}
