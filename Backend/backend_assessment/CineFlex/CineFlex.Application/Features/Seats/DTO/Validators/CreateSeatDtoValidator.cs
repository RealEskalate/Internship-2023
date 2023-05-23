using CineFlex.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class CreateSeatDtoValidator:AbstractValidator<CreateSeatDto>
    {

         private readonly IUnitOfWork _unitOfWork;
        public CreateSeatDtoValidator(IUnitOfWork UnitOfWork)
        {

              _unitOfWork = UnitOfWork;
            Include(new ISeatDtoValidator());
        }
        
    }
}
