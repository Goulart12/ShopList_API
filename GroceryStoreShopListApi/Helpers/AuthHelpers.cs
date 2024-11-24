using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GroceryStoreShopListApi.Authorization.Models;
using Microsoft.IdentityModel.Tokens;

namespace GroceryStoreShopListApi.Helpers;

public class AuthHelpers : IAuthHelpers
{
    private readonly IConfiguration _configuration;

    public AuthHelpers(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(User user) {
        var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
        };
        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"])
                ),
                SecurityAlgorithms.HmacSha256Signature)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    public string GetCurrentUserId(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        
        var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
        return claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
    }
}