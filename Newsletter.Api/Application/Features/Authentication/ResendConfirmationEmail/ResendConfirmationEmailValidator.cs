using FluentValidation;

namespace Newsletter.Api.Application.Features.Authentication.ResendConfirmationEmail;

public class ResendConfirmationEmailValidator : AbstractValidator<ResendConfirmationEmailCommand>
{
    public ResendConfirmationEmailValidator()
    {
        RuleFor(x => x.email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Email is not in correct format");
    }
}
