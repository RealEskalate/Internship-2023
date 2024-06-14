
using System.Threading.Tasks;
using CineFlex.Application.Models;
using CineFlex.Application.Models.DTOs;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password, string roles);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateUserAsync(string userId, ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task DeleteUserAsync(string userId);
        Task<bool> CheckEmailExistence(string email, string? userId);
        Task<ApplicationUser> GetUserById(string userId);
        Task ResetPassword(string userId, string password);
        Task<LoginResponse> LoginAsync(string username, string password);

        string GenerateToken(ApplicationUser user);
    }
}
