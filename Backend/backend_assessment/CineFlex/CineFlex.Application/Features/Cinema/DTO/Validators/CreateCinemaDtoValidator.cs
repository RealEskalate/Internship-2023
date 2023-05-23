using FluentValidation;

namespace CineFlex.Application.Features.Cinema.DTO.Validators;

public class CreateCinemaDtoValidator : AbstractValidator<CreateCinemaDto>
{
    public CreateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());
    }
}