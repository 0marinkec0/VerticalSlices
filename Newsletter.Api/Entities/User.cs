using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Newsletter.Api.Entities;

public class User : IdentityUser<int>
{
    public List<Post> Posts { get; set; }

    public List<Vote> Votes { get; set; }

    private User() { }

    public static User CreateUser(string userName, string email)
    {
        var user = new User
        {
            UserName = userName,
            Email = email
        };

        return user;
    }

    public static List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
        new Claim(ClaimTypes.Name, user.UserName!),
        new Claim(ClaimTypes.Email, user.Email!),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
    }
}
