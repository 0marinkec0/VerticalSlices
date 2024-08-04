using MediatR;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.DownvotePost;

public record DownvotePostCommand(int postId) : IRequest<Result>;

