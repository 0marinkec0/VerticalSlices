using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.Commands.UpvotePost;

public record UpvotePostCommand(int postId) : IRequest<Result>;

