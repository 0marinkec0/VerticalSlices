using MediatR;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
{
    private readonly IIdentityService _identityService;

    public ConfirmEmailCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.ConfirmEmail(request.email, request.token);

        return result;
    }
}
