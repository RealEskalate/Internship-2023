using CineFlex.Domain;
using Microsoft.IdentityModel.Tokens;

namespace CineFlex.Infrastructure.Identity;

public interface IJwtFactory
{
    Task<SecurityToken> GenerateToken(AppUser user);
}