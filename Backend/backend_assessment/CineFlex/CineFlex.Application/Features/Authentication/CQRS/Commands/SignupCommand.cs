
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Authentication.CQRS.Commands;

public class SignupCommand: IRequest<BaseCommandResponse<SignupResponse>>
{
    public SignupFromDto SignupForm { get; set; } = null!;
}