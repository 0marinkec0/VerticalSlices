using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.Login;

public record LoginCommand(string email, string password) : IRequest<Result<string>>;

