using FluentValidation;

namespace CineFlex.Application.Features.Authentication.DTOs.Validators
{
    public class UserSignUpDtoValidator : AbstractValidator<UserSignUpDTO>
    {

        public UserSignUpDtoValidator()
        {
            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(7).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");
        }
    }
}
