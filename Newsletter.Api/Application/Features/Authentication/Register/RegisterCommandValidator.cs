using FluentValidation;

namespace Newsletter.Api.Application.Features.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Email is not in correct format");

        RuleFor(x => x.password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must have atleast 6 characters")
            .Matches("[A-Z]").WithMessage("Password must have at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must have at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must have at least one number");
    }
}
