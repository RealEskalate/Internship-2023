using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class CreateTicketDtoValidator : AbstractValidator<CreateTicketDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(dto => dto.SeatID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(async (int id, CancellationToken token) => {
                    return await _unitOfWork.TicketRepository.Exists(id);
                }).WithMessage("{PropertyName} with a the specified id '{PropertyValue}' does not exist.")
                .MustAsync(async (int id, CancellationToken token) => {
                    var seat = await _unitOfWork.SeatRepository.Get(id);
                    return seat.Available;
                }).WithMessage("The seat is not available");

            RuleFor(dto => dto.UserID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync((string id, CancellationToken token) => {
                    return _unitOfWork.UserRepository.Exists(id);
                }).WithMessage("{PropertyName} with a the specified id '{PropertyValue}' does not exist.");
        }

    }
}
