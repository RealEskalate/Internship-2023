using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Features.Seats.DTO.Validators;
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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeatDtoValidator(IUnitOfWork UnitOfWork)
        {

            _unitOfWork = UnitOfWork;
            Include(new ISeatDtoValidator(_unitOfWork));
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await _unitOfWork.SeatRepository.Exists(id);
                })
                .WithMessage("{PropertyName} does't exist");

        }
    }
}

