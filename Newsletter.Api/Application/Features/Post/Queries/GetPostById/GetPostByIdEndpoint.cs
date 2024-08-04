using Carter;
using MediatR;

namespace Newsletter.Api.Application.Features.Post.Queries.GetPostById;

public class GetPostByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/get-by-id/{id}", async (int id, ISender sender) =>
        {
            var query = new GetPostByIdQuery(id);

            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return Results.NotFound(result.Error);
            }

            return Results.Ok(result.Value);
        });
    }
}
