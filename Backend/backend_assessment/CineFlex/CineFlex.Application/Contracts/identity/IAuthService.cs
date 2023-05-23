using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Models.Identity;

namespace CineFlex.Application.Contracts.Identity;
public interface IAuthService
{
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest model);
    Task<AuthResponse> LoginAsync(AuthRequest model);
}

