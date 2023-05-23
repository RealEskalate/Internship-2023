using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new ISeatDtoValidator());

            RuleFor(p => p.CinemaId)
             .GreaterThan(0)
            .MustAsync(async (id, token) => {
                 return await _unitOfWork.CinemaRepository.Exists(id);
             })
             .WithMessage("{PropertyName} does't exist");
        }
    }
}