using Microsoft.AspNetCore.Identity;
using CineFlex.Domain.Models;
using CineFlex.Application.Features.Authentication.DTOs;

namespace CineFlex.Application.Contracts.Persistence{
    public interface IUserRepository: IGenericRepository<AppUser>
    {
        Task<IdentityResult> RegisterUserAsync(AppUser userForRegistration);
        Task<bool> ValidateUserAsync(UserSignInDTO loginDto); 
        Task<string> CreateTokenAsync(); 
        Task<bool> Exists(string id);
        Task<AppUser?> Get(string id);
    }

}
