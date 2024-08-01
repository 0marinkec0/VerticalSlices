using Newsletter.Api.Shared;

namespace Newsletter.Api.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result> Register(string userName, string email, string password);
    Task<Result<string>> Login(string email, string password);
    Task<Result<string>> GetEmailConfirmationTokenAsync(string email);
    Task<Result> ConfirmEmail(string email, string token);
}
