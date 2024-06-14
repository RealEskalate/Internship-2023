using FluentValidation;


namespace CineFlex.Application.Features.Authentication.DTOs.Validators
{
    public class UserSignInDtoValidator : AbstractValidator<UserSignInDTO>
    {

        public UserSignInDtoValidator()
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(100).WithMessage("Username must not exceed 100 characters.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(7).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");
        }
    }
}
