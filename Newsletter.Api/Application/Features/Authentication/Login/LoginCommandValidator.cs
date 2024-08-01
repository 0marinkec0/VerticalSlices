using FluentValidation;

namespace Newsletter.Api.Application.Features.Authentication.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Email is not in correct format");

        RuleFor(x => x.password)
            .NotEmpty().WithMessage("Password is required");
    }
}
