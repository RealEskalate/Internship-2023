using CineFlex.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public ISeatDtoValidator()
        {
        }

        public ISeatDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;

            RuleFor(p => p.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.CinemaId)
                  .GreaterThan(0)
                  .MustAsync(async (id, token) =>
                  {
                      return await _unitOfWork.CinemaRepository.Exists(id);
                  })
                  .WithMessage("{PropertyName} does't exist");




        }
    }
}

