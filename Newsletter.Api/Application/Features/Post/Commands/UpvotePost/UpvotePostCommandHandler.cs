using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Infrastructure.Database.Persistent;
using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Features.Post.Commands.UpvotePost;

public class UpvotePostCommandHandler : IRequestHandler<UpvotePostCommand, Result>
{
    private readonly AppDbContext _appDbContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;

    public UpvotePostCommandHandler(AppDbContext appDbContext, ICurrentUserService currentUserService, IIdentityService identityService, IUnitOfWork unitOfWork)
    {
        _appDbContext = appDbContext;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpvotePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _appDbContext.Posts.Include(v => v.Votes).FirstOrDefaultAsync(a => a.Id == request.postId);

        if(post == null)
        {
            return Result.Failure(new Error(code: "Post.PostNotFound", message: $"Post with Id {request.postId} was not found"));
        }

        var user = await _identityService.GetUserByIdAsync(_currentUserService.UserId);

        var upvoteResult = post.Upvote(user.Value, request.postId);

        if (upvoteResult.IsSuccess)
        {
            _appDbContext.Posts.Update(post);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
        return upvoteResult;
    }
}
