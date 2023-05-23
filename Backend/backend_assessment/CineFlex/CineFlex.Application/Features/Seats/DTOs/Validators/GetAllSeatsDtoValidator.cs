using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class GetAllSeatsDtoValidator: AbstractValidator<GetAllSeatsDto>
{
    public GetAllSeatsDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Movie)
            .MustAsync(async (id, token) => await unitOfWork.MovieRepository.Exists(id)).WithMessage($"Movie not found");

        RuleFor(m => m.Cinema)
            .MustAsync(async (id, token) => await unitOfWork.CinemaRepository.Exists(id)).WithMessage($"Cinema not found");
    }
}