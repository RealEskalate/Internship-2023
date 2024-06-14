using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CineFlex.Domain;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Distributed;

namespace CineFlex.API.Services
{
    public class TokenService
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _config;
        public TokenService(IDistributedCache cache, IConfiguration config)
        {
            _cache = cache;
            _config = config;
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(4),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenBytes = Encoding.UTF8.GetBytes(tokenHandler.WriteToken(token));
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(tokenDescriptor.Expires.Value);
            _cache.Set(user.Email, tokenBytes, options);

            return tokenHandler.WriteToken(token); ;

        }


        public string GetTokenFromRequest(HttpContext context)
        {

            var authorizationHeader = context.Request.Headers["Authorization"].ToString();

            // Check if the Authorization header is present and formatted correctly
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Extract the token from the Authorization header
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                return token;
            }

            return null; // Token not found in the request
        }

        public void RevokeToken(string email)
        {
            // Remove the token from the distributed cache using the user's email as the cache key
            _cache.Remove(email);
        }

        public bool IsTokenRevoked(string email, string token)
        {
            // Check if the token is present in the distributed cache using the user's email as the cache key
            var cachedTokenBytes = _cache.Get(email);
            if (cachedTokenBytes == null)
                return true; // Token is revoked if not found in cache

            var cachedToken = Encoding.UTF8.GetString(cachedTokenBytes);

            return !token.Equals(cachedToken);
        }









    }
}
