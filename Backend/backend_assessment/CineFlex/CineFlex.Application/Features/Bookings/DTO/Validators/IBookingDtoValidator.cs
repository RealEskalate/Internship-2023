using CineFlex.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO.Validators
{
    public class IBookingDtoValidator : AbstractValidator<IBookingDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public IBookingDtoValidator()
        {
        }

        public IBookingDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;



            RuleFor(p => p.MovieId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await _unitOfWork.MovieRepository.Exists(id);
                })
                .WithMessage("{PropertyName} does't exist");

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

