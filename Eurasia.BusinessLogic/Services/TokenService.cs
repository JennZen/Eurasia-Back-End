using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Services
{
    public class TokenService
    {
        private const string Issuer = "EurasiaApi";
        private const string Audience = "EurasiaClients";
        private const string SecretKey = "tw_curs2026_super_secret_min_32_caractere!";

        public string GenerateToken(int userId, string userName, string role)
        {
            //1. Симметричный ключ из секрета
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //2. Claims = данные, которые кладём в payload
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role) 
            };

            //3. Собираем токен
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            //4. Сериализируем в Header.Payload.Signature
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
