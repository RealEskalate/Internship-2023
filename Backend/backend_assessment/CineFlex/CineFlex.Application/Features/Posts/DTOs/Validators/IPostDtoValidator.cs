using FluentValidation;

namespace CineFlex.Application.Features.Posts.DTOs.Validators
{
    public class IPostDtoValidator : AbstractValidator<IPostDto>
    {
        public IPostDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
