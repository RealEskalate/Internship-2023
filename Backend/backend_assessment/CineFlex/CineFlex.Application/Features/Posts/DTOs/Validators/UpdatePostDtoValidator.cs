using FluentValidation;

namespace CineFlex.Application.Features.Posts.DTOs.Validators
{
    public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostDtoValidator()
        {
            Include(new IPostDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }

    }
}