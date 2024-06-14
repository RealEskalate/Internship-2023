using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Authentication.DTOs
{
    public class SignInResponse : SignUpResponse
    {
        public string Token { get; set; }
    }
}
