using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.ConfirmEmail;

public record ConfirmEmailCommand(string email, string token) : IRequest<Result>;

