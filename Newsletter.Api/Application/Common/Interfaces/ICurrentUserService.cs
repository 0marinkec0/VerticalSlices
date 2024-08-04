namespace Newsletter.Api.Application.Common.Interfaces;

public interface ICurrentUserService
{
    int UserId { get; }
    string Email { get; }
}
