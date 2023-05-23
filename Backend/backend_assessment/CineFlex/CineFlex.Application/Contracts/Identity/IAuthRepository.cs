using CineFlex.Application.Features.Authentication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Identity
{
    public interface IAuthRepository
    {
        Task<SignUpResponse> SignUpAsync(SignupFormDto signUpFormDto);
        Task<SignInResponse> SignInAsync(SigninFormDto signInFormDto);
    }
}
