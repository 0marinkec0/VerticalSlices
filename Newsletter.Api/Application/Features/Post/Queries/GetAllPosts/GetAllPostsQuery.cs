using MediatR;

namespace Newsletter.Api.Application.Features.Post.GetAllPosts;

public record GetAllPostsQuery : IRequest<List<PostDto>>;
