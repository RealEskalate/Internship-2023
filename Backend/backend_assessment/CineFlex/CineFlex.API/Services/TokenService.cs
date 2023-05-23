using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CineFlex.Domain;
using Microsoft.IdentityModel.Tokens;


namespace  CineFlex.API.Services
{
   public class TokenService 
   {    
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;   
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);;

        }
   } 
}