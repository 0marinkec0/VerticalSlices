using Carter;
using MediatR;

namespace Newsletter.Api.Application.Features.Authentication.ConfirmEmail;

public class ConfirmEmailEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/confirm-email", async (ConfirmEmailCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            if (result.IsSuccess)
            {
                return Results.Ok();
            }

            return Results.BadRequest(result.Error);
        });
    }
}
