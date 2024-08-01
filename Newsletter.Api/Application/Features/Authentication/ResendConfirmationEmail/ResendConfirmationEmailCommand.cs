using MediatR;

namespace Newsletter.Api.Application.Features.Authentication.ResendConfirmationEmail;

public record ResendConfirmationEmailCommand(string email) : IRequest;

