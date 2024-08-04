using MediatR;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Application.Features.Post.CreatePost;
using Newsletter.Api.Entities;
using Newsletter.Api.Infrastructure.Database.Persistent;

using PostNameSpace = Newsletter.Api.Application.Features.Post.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
{
    private readonly IIdentityService _identityService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _appDbContext;

    public CreatePostCommandHandler(IIdentityService identityService, AppDbContext appDbContext, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    {
        _identityService = identityService;
        _appDbContext = appDbContext;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;

        var user = await _identityService.GetUserByIdAsync(currentUserId);

        if (user.IsSuccess)
        { 
           var post = Post.CreatePost(request.title, request.content, user.Value);

           await _appDbContext.AddAsync(post);

           await _unitOfWork.SaveChangesAsync();
        }
            
    }
}
