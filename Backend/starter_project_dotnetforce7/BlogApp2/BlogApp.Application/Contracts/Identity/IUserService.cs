using BlogApp.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


using BlogApp.Domain.Models.Identity;

namespace BlogApp.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(string userId);
    }
}
