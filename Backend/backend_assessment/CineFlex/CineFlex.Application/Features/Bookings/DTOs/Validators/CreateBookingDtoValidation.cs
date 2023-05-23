using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.DTOs;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IBookingDtoValidator(_unitOfWork));
        }
    }
}