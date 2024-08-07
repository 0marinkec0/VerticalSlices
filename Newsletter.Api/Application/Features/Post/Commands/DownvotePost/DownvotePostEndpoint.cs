﻿using Carter;
using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.DownvotePost;

public class DownvotePostEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/downvote-post", async (DownvotePostCommand command, ISender sender) =>
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
