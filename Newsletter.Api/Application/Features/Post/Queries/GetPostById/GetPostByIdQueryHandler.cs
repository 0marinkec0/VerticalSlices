using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsletter.Api.Application.Features.Post.GetAllPosts;
using Newsletter.Api.Infrastructure.Database.Persistent;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.Queries.GetPostById;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<PostDto>>
{
    private readonly AppDbContext _appDbContext;

    public GetPostByIdQueryHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Result<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _appDbContext.Posts.FirstOrDefaultAsync(a => a.Id == request.id);

        if (post == null)
        {
           return Result<PostDto>.Failure(new Error(code: "Posts.NotFound", message: $"Post with Id: {request.id} was not found!"));
        }

        var response = new PostDto { 
            Id = request.id,
            Title = post.Title,
            Content = post.Content,
            UserId = post.UserId,
            Upvotes = post.Upvotes,
            Downvotes = post.Downvotes,
        };

        return Result<PostDto>.Success(response);
    }
}
