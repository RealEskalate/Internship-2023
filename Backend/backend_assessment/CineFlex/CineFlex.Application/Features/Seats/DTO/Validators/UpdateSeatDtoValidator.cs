using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.RowNumber).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.SeatNumber).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.SeatType).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.CinemaHallId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
