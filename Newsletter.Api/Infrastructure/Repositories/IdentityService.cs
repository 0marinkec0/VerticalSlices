using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newsletter.Api.Application.Common.Interfaces;
using Newsletter.Api.Application.Features.Authentication.JwtProvider;
using Newsletter.Api.Entities;
using Newsletter.Api.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Newsletter.Api.Infrastructure.Repositories;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(UserManager<User> userManager, IOptions<JwtOptions> options)
    {
        _userManager = userManager;
        _jwtOptions = options.Value;
    }
    /// <summary>
    /// Registers user, while checking unique email and other possible register errors provided by UserManager class.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<Result> Register(string userName, string email, string password)
    {
       // var result = await _userManager.FindByEmailAsync(email);

        var user = User.CreateUser(userName, email);

        var registerUser = await _userManager.CreateAsync(user);

        var customErrors = registerUser.Errors.Select(a => new Error(code: "IdentityErrors.UserManager", message: a.Description)).ToArray();
       
        return registerUser.Succeeded ?
            Result.Success() :
            ValidationResult.WithErrors(customErrors);
    }

    public async Task<Result<string>> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return Result<string>.Failure(new Error(code: "DomainError.WrongEmail", message: $"User with email {email} does not exist"));
        }

        var checkPassword = !await _userManager.CheckPasswordAsync(user, password);

        if (checkPassword == false)
        {
            return Result<string>.Failure(new Error(code: "DomainError.WrongPassword", message: $"Wrong password"));
        }

        var checkIfEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (checkIfEmailConfirmed == false)
        {
            return Result<string>.Failure(new Error(code: "DomainError.EmailNotConfirmed", message: $"Email {email} is not confirmed"));
        }

        var claims = User.GetClaims(user);

        var token = GenerateToken(claims);

        return Result<string>.Success(token);
    }

    private string GenerateToken(List<Claim> claims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey!)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
           issuer: _jwtOptions.Issuer,
           audience: _jwtOptions.Audience,
           claims: claims,
           null,
           expires: DateTime.UtcNow.AddHours(1),
           signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);      
    }

    public async Task<Result> ConfirmEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if(user is null)
        {
           return Result.Failure(new Error(code: "DomainError.ConfrimEmailError", message: $"User with {email} is not found"));
        }

        await _userManager.ConfirmEmailAsync(user, token);

        return Result.Success();
    }

    public async Task<Result<string>> GetEmailConfirmationTokenAsync(string email)
    { 
        var user = await _userManager.FindByEmailAsync(email);

        if(user is null) 
        {
            return Result<string>.Failure(new Error(code: "DomainError.WrongEmail", message: $"User with email {email} does not exist"));
        }

       var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        return Result<string>.Success(token);
    }

    public async Task<Result<User>> GetUserByIdAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return Result<User>.Failure(new Error(code: "IdentityError.UserNotFound", message: $"User with id {id} was not found"));
        }

        return Result<User>.Success(user);
    }
}
