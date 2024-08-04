using MediatR;

namespace Newsletter.Api.Application.Features.Post.CreatePost;

public record CreatePostCommand(string title, string content) : IRequest;
