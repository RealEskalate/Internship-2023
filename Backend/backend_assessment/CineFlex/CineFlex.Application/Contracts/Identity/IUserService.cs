using CineFlex.Application.Models.Identity;

namespace CineFlex.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    
    Task<User?> GetUser(string userId);

    Task<bool> Exists(string userId);

    Task<bool> IsAdmin(string userId);

}
