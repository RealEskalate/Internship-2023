using CineFlex.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO.Validators
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingDtoValidator(IUnitOfWork UnitOfWork)
        {

            _unitOfWork = UnitOfWork;
            Include(new IBookingDtoValidator(_unitOfWork));

            // RuleFor(p => p)
            //  .MustAsync(async (p, token) =>
            //  {
            //      foreach (var seatNumber in p.SeatNumbers)
            //      {
            //          var isSeatTaken = await _unitOfWork.SeatRepository.IsSeatTakenAsync(seatNumber, p.CinemaId);
            //          if (isSeatTaken)
            //              return false;
            //      }
            //      return true;
            //  })
            //  .WithMessage("Some seat numbers are already taken");
        }

    }
}
