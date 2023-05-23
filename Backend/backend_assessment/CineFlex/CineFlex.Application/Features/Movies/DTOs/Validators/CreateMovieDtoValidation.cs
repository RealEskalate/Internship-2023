using FluentValidation;

namespace CineFlex.Application.Features.Movies.DTOs.Validators;

public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
{
    public CreateMovieDtoValidator()
    {
        Include(new IMovieDtoValidator());
    }
}