using MediatR;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.ResendConfirmationEmail;

public class ResendConfirmationEmailCommandHandler : IRequestHandler<ResendConfirmationEmailCommand>
{
    private readonly IIdentityService _identityService;
    private readonly IEmailService _emailService;

    public ResendConfirmationEmailCommandHandler(IIdentityService identityService, IEmailService emailService)
    {
        _identityService = identityService;
        _emailService = emailService;
    }

    public async Task Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
    {
        Result<string> resultToken = await _identityService.GetEmailConfirmationTokenAsync(request.email);
        await _emailService.SendConfirmEmail(request.email, resultToken.Value);
    }
}
