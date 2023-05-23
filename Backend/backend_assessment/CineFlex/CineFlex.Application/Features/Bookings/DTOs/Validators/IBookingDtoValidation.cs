using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators
{
    public class IBookingDtoValidator : AbstractValidator<IBookingDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IBookingDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.CinemaId)
              .GreaterThan(0)
              .MustAsync(async (id, token) => {
                  return await _unitOfWork.CinemaRepository.Exists(id);
              })
              .WithMessage("{PropertyName} does't exist");

            RuleFor(p => p.MovieId)
               .GreaterThan(0)
               .MustAsync(async (id, token) => {
                   return await _unitOfWork.MovieRepository.Exists(id);
               })
               .WithMessage("{PropertyName} does't exist");

            RuleFor(p => p.SeatsId)
                .Must( sts=> sts.GetType() == typeof(List<int>))
                .WithMessage("{ProperyName} must be Collection int")
                .MustAsync( async( sts,token) =>
                {
                    foreach (int st in sts)
                    {
                        if (!await _unitOfWork.SeatRepository.Exists(st))
                            return false;
                    }
                    return true;
                })
                .WithMessage("{ProperyName} not found");
        }
    }
}
