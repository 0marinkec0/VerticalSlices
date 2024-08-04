using Newsletter.Api.Application.Common.Interfaces;
using System.Security.Claims;

namespace Newsletter.Api.Infrastructure.Repositories;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int UserId => Convert.ToInt32(_contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

    public string Email => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);        
}
