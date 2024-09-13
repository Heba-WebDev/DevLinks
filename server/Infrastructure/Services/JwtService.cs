using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace Infrastructure.Services;

public class JwtService
{
    private readonly string _secret;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expiryMinutes;
    private readonly int _resetTokenExpiryMinutes;

    public JwtService(IConfiguration config)
    {
        _secret = config["JwtSettings:Secret"]!;
        _issuer = config["JwtSettings:Issuer"]!;
        _audience = config["JwtSettings:Audience"]!;
        _expiryMinutes = int.Parse(config["JwtSettings:ExpiryMinutes"]!);
        _resetTokenExpiryMinutes = int.Parse(config["JwtSettings:ResetTokenExpiryMinutes"]!);
    }

    public string GenerateResetToken(string userId, string userRole, string email)
    {
        var claims = new []
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, userRole),
            new Claim("purpose", "reset_password")
        };
        return CreateToken(claims, _resetTokenExpiryMinutes);
    }

    public string GenerateToken(string userId, string userRole)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, userRole),
            new Claim("purpose", "reset_password")
        };
        return CreateToken(claims, _expiryMinutes);
    }

    public string CreateToken(Claim[] claims, int expiryMinutes)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiryMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public (bool IsValid, string? UserId, string? ErrorMessage) ValidatePasswordResetToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        try
        {
            var validateParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };

            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validateParameters, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Subject;
            var purpose = jwtToken.Claims.FirstOrDefault(x => x.Type == "purpose")?.Value;
            if (purpose != "reset_password")
            {
                return (false, null, "Invalid token purpose");
            }
            return (true, userId, null);
        }
        catch (SecurityTokenException)
        {
            return (false, null, "Token has expired");
        }
        catch (Exception)
        {
            return (false, null, "Invalid token");
        }
    }
}