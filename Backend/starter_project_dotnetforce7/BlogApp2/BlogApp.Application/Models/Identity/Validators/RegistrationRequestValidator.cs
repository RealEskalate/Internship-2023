using BlogApp.Application.Features.Blogs.DTOs;
using FluentValidation;

namespace BlogApp.Application.Models.Identity.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationRequestValidator()
    {
        RuleFor(req => req.Firstname).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        RuleFor(req => req.Lastname).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        RuleFor(req => req.Username).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        RuleFor(req => req.Email).NotEmpty().NotNull().WithMessage("{PropertyName} is required").EmailAddress();
        RuleFor(req => req.Password).NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required").MinimumLength(8)
            .WithMessage("{PropertyName} must be at least 8 characters long")
            .Matches("^(?=.*\\d)(?=.*\\W).+$")
            .WithMessage("{PropertyName} must contain at least one special character and one number.");
    }
}