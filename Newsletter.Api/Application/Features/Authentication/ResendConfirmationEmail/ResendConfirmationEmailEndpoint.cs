using Carter;
using MediatR;

namespace Newsletter.Api.Application.Features.Authentication.ResendConfirmationEmail;

public class ResendConfirmationEmailEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/resend-confirmation-email", async (ResendConfirmationEmailCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });
    }
}
