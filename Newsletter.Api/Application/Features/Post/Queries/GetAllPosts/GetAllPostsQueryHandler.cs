using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsletter.Api.Infrastructure.Database.Persistent;

namespace Newsletter.Api.Application.Features.Post.GetAllPosts;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostDto>>
{
    private readonly AppDbContext _appDbContext;
    

    public GetAllPostsQueryHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var postList = await _appDbContext.Posts.Select(n => new PostDto
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            UserId = n.UserId,
            Upvotes = n.Upvotes,
            Downvotes = n.Downvotes,
            CalculateVotes = n.CalculateVotes
        }).ToListAsync();

        return postList;
    }
}
