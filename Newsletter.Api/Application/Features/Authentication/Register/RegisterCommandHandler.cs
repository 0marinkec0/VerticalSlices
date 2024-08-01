using MediatR;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private readonly IIdentityService _identityService;
    private readonly IEmailService _emailService;

    public RegisterCommandHandler(IIdentityService authenticationRepository, IEmailService emailService)
    {
        _identityService = authenticationRepository;
        _emailService = emailService;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.Register(request.userName, request.email, request.password);
     
        if (result.IsSuccess)
        {
            Result<string> resultToken = await _identityService.GetEmailConfirmationTokenAsync(request.email);
            await _emailService.SendConfirmEmail(request.email, resultToken.Value);
        }

        return result;
    }
}
