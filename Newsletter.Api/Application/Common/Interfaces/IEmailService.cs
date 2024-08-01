namespace Newsletter.Api.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendConfirmEmail(string email, string token);
}
