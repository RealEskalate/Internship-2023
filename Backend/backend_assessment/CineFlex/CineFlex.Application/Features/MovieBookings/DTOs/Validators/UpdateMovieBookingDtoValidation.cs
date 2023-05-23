using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.DTOs.Validators
{
    public class UpdateMovieBookingDtoValidator : AbstractValidator<UpdateMovieBookingDto>
    {
        public UpdateMovieBookingDtoValidator()
        {
            Include(new IMovieBookingDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
