using CineFlex.Application.Features.Movies.DTOs;
using FluentValidation;

namespace CineFlex.Application.Features.Movies.Validators
{
    public class BookMovieDtoValidator : AbstractValidator<BookMovieDto>
    {
        public BookMovieDtoValidator()
        {
            RuleFor(dto => dto.MovieId).NotEmpty().WithMessage("MovieId is required.");
            RuleFor(dto => dto.CinemaId).NotEmpty().WithMessage("CinemaId is required.");
            RuleFor(dto => dto.Seats).NotEmpty().WithMessage("Seats list is required.");
            RuleForEach(dto => dto.Seats).NotEmpty().WithMessage("Seat in Seats list cannot be empty.");
        }
    }
}
