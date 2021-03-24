using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sample.Application.Common.Interfaces;
using Sample.Application.Common.Securtiy;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public Token CreateAccessToken(int durationInSeconds)
        {
            Token token = new Token();

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Sample.WebApi"))
            .AddJsonFile("appsettings.json")
            .Build();

            //Security Key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]));

            //Kimlik
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddSeconds(durationInSeconds);

            //JWT Konfigürasyonu
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now, //Token üretildikten ne kadar süre sonra devreye girsin
                signingCredentials: signingCredentials,
                claims: new List<Claim> {
                    new(ClaimTypes.Role, "misafir"),
                    new("abc", "xyz"),
                    new("tarih",DateTime.Now.ToShortTimeString()),
                    new("site","https://www.google.com"),
                    new("adres","eskişehir, istiklal"),
                    new("adisoyad","asdkalsd alsödlaösd"),
                    new("sirket","Nurettin Nakliyat")
                });

            //Token oluşturucu
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] numbers = new byte[32];
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(numbers);
            return Convert.ToBase64String(numbers);
        }

        public Token GetEmptyToken()
        {
            return new Token
            {
                AccessToken = "",
                Expiration = DateTime.Now,
                RefreshToken = "",
            };
        }
    }
}
