namespace Newsletter.Api.Application.Features.Authentication.JwtProvider;

public class JwtOptions
{
    public string? Issuer { get; init; }

    public string? Audience { get; init; }

    public string? SecretKey { get; init; }
}
