using Carter;
using MediatR;

namespace Newsletter.Api.Application.Features.Post.GetAllPosts;

public class GetAllPostsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/get-all-posts", async (ISender sender) =>
        {
            var request = new GetAllPostsQuery();

            var posts = await sender.Send(request);

            return Results.Ok(posts);
        });
    }
}
