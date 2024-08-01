using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.Register;

public record RegisterCommand(string email, string userName, string password) : IRequest<Result>;

