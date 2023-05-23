using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class UpdateSeatDtoValidation : AbstractValidator<UpdateSeatDto>
{
    private readonly ISeatRepository _seatRepository;


    public UpdateSeatDtoValidation(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;

        Include(new ISeatDtoValidation());

        RuleFor(dto => dto.Id).NotEmpty().WithMessage("Id is required.").MustAsync((i, token) =>
            _seatRepository.Exists(i)
        ).WithMessage("Seat with given id doesn't exist.");
    }
}