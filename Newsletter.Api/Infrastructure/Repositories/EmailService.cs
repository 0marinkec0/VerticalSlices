using Newsletter.Api.Application.Common.Interfaces;
using System.Security.Principal;

namespace Newsletter.Api.Infrastructure.Repositories;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public async Task SendConfirmEmail(string email, string token)
    {
        _logger.LogInformation(token);
    }
}
