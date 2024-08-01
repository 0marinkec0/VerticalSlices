using Carter;
using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Authentication.Register;

public class RegisterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/register", async (RegisterCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            if (result.IsSuccess)
            {
                return Results.Ok();
            }

            return FailureHandler.HandleFailure(result);
        });
    }
}
