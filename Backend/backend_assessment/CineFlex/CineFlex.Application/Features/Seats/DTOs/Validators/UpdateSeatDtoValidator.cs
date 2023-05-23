using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeatDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(dto => dto.Name)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must be of length {ComparisonValue}.");
        }

    }
}
