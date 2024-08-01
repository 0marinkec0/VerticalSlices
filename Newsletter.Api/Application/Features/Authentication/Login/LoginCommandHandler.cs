using MediatR;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Shared;


namespace Newsletter.Api.Application.Features.Authentication.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IIdentityService _identityService;

    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.Login(request.email, request.password);

        return result;
    }
}
