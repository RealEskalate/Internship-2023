using BlogApp.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;




namespace BlogApp.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<ApplicationUserDTO>> GetUsers();
        Task<ApplicationUserDTO> GetUser(string userId);
        Task<ApplicationUserDTO> GetCurrentUser();
    }
}
