using CineFlex.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Identity
{
    public class IUserService
    {
        Task<List<Blogger>> GetBloggers();
        Task<Blogger?> GetBlogger(string UserId);
    }
}
