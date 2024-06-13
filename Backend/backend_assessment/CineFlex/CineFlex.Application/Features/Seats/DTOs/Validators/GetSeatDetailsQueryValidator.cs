using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Requests.Queries;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class GetSeatDetailsQueryValidator: AbstractValidator<GetSeatDetailsQuery>
{
    public GetSeatDetailsQueryValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Id)
            .MustAsync(async (id, token) => await unitOfWork.SeatRepository.Exists(id)).WithMessage($"Seat not found");
    }
}