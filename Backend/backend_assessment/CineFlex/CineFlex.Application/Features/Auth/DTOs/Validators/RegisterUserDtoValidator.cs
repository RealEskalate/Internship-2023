using FluentValidation;

namespace CineFlex.Application.Features.Auth.DTOs.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(dto => dto.UserName).NotEmpty().WithMessage("UserName is required").MinimumLength(6).MaximumLength(20)
            .WithMessage("UserName should be between 6 and 20 characters long.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .MaximumLength(20).WithMessage("Password must not exceed 20 characters");
    }
}