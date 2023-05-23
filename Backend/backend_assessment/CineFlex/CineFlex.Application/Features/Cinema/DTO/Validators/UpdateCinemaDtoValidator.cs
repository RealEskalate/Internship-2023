using FluentValidation;

namespace CineFlex.Application.Features.Cinema.DTO.Validators;

public class UpdateCinemaDtoValidator : AbstractValidator<UpdateCinemaDto>
{
    public UpdateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());
        RuleFor(a => a.Id)
            .NotNull()
            .WithMessage("{PropertyName} must be present");
    }
}