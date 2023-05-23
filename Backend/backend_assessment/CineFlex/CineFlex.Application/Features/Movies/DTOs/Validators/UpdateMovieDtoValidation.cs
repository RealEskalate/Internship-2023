using FluentValidation;

namespace CineFlex.Application.Features.Movies.DTOs.Validators;

public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
{
    public UpdateMovieDtoValidator()
    {
        Include(new IMovieDtoValidator());

        RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}