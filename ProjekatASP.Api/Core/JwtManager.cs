using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Api.Core
{
    public class JwtManager
    {
        private readonly ProjekatASPContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;

        public JwtManager(ProjekatASPContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string email, string password)
        {
            var userDb = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (userDb == null)
            {
                return null;
            }

            var user = new JwtUser();

            if (userDb.RoleId == 1)
            {
                user = new JwtUser
                {
                    Id = userDb.Id,
                    Email = userDb.Email,
                    AllowedUseCases = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }
                };
            }
            else
            {
                user = new JwtUser
                {
                    Id = userDb.Id,
                    Email = userDb.Email,
                    AllowedUseCases = new List<int> { 1, 5, 9, 13, 17, 19, 21 }
                };
            }

            var issuer = _issuer;
            var secretKey = _secretKey;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("UserData", JsonConvert.SerializeObject(user), ClaimValueTypes.String, issuer),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;

            var token = new JwtSecurityToken
                (
                    issuer : issuer,
                    audience : "Any",
                    claims : claims,
                    notBefore : now,
                    expires : now.AddSeconds(90),
                    signingCredentials : credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
