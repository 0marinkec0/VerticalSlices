using Carter;
using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.Commands.UpvotePost
{
    public class UpvotePostCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/upvote-post", async (UpvotePostCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);

                if (result.IsSuccess)
                {
                    return Results.Ok();
                }

                return FailureHandler.HandleFailure(result);

            }).RequireAuthorization();
        }
    }
}
