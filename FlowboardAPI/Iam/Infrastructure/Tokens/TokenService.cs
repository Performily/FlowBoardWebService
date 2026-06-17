using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Performily.IAM.Iam.Domain.Model.Aggregates;
using Performily.IAM.Iam.Application.OutboundServices;

namespace Performily.IAM.Iam.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        // Llave secreta de firma (debe tener al menos 256 bits / 32 caracteres)
        var key = Encoding.ASCII.GetBytes("EstaEsUnaLlaveSuperSecretaDePerformily2026!"); 

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email.Value),
                new Claim(ClaimTypes.Role, user.Role) // El Rol dinámico para tu Front
            }),
            Expires = DateTime.UtcNow.AddDays(7), // Tiempo expiración
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}