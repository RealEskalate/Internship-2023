using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Bookings.DTO.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO.Validators
{
    public class UpdateBookingDtoValidator : AbstractValidator<UpdateBookingDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookingDtoValidator(IUnitOfWork UnitOfWork)
        {

            _unitOfWork = UnitOfWork;
            Include(new IBookingDtoValidator(_unitOfWork));
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await _unitOfWork.BookingRepository.Exists(id);
                })
                .WithMessage("{PropertyName} does't exist");

        }
    }
}

