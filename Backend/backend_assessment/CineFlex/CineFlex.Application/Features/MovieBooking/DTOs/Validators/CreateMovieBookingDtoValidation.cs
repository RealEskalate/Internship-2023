using System.Data;
using CineFlex.Application.Contracts.Persistence;
using FluentValidation;

namespace CineFlex.Application.Features.MovieBooking.DTOs.Validators;

public class CreateMovieBookingDtoValidation : AbstractValidator<CreateMovieBookingDto>
{
    public CreateMovieBookingDtoValidation(IUnitOfWork unitOfWork)
    {
        // TODO: Check that the seats are inside the cinema
        RuleFor(dto => dto.CinemaId).NotEmpty().WithMessage("CinemaId is required").MustAsync(
            (i, token) =>
                unitOfWork.CinemaRepository.Exists(i)
        );

        RuleFor(dto => dto.MovieId).NotEmpty().WithMessage("MovieId is required").MustAsync(
            (i, token) =>
                unitOfWork.CinemaRepository.Exists(i)
        );

        RuleFor(dto => dto.SeatIds).NotEmpty().WithMessage("SeatIds required").MustAsync(async (ids, token) =>
            {
                foreach (var id in ids)
                {
                    if (!await unitOfWork.SeatRepository.Exists(id))
                        return false;
                }

                return true;
            }
        ).WithMessage("Some seats don't exist.");
    }
}