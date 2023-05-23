using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());
            RuleFor(a => a.Id)
           .NotNull()
           .WithMessage("{PropertyName} must be present");
        }
    }
}