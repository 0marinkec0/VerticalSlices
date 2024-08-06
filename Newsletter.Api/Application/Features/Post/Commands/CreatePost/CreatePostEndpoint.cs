using Carter;
using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.CreatePost;

public class CreatePostEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/create-post", async (CreatePostCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();
    }
}
