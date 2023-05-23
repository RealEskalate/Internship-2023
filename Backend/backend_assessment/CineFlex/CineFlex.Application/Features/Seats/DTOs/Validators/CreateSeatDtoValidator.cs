using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(dto => dto.CinemaID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync((int id, CancellationToken token) => {
                    return _unitOfWork.CinemaRepository.Exists(id);
                }).WithMessage("{PropertyName} with a the specified id '{PropertyValue}' does not exist.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must be of length {ComparisonValue}.");
        }

    }
}
