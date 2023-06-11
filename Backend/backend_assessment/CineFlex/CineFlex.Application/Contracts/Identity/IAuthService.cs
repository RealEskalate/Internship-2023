using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> Login(AuthRequest authRequest);
        Task<Result<RegistrationResponse>> Registor(RegistrationRequest registrationRequest);
    }
}
