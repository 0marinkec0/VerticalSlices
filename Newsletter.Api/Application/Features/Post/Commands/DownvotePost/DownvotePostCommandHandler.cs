using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Infrastructure.Database.Persistent;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.DownvotePost;

public class DownvotePostCommandHandler : IRequestHandler<DownvotePostCommand, Result>
{
    private readonly AppDbContext _appDbContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;

    public DownvotePostCommandHandler(AppDbContext appDbContext, ICurrentUserService currentUserService, IIdentityService identityService, IUnitOfWork unitOfWork)
    {
        _appDbContext = appDbContext;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DownvotePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _appDbContext.Posts.Include(x => x.Votes).FirstOrDefaultAsync(a => a.Id == request.postId);

        if (post == null)
        {
            return Result.Failure(new Error(code: "Post.PostNotFound", message: $"Post with Id {request.postId} was not found"));
        }

        var user = await _identityService.GetUserByIdAsync(_currentUserService.UserId);

        var downvoteResult = post.Downvote(user.Value, request.postId);

        if (downvoteResult.IsSuccess)
        {
            _appDbContext.Posts.Update(post);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        return downvoteResult;
    }
}
