using MediatR;
using Newsletter.Api.Application.Features.Post.GetAllPosts;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.Queries.GetPostById;

public record GetPostByIdQuery(int id) : IRequest<Result<PostDto>>;
