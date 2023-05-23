using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class CreateSeatDtoValidator: AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());
        }
        
    }
}