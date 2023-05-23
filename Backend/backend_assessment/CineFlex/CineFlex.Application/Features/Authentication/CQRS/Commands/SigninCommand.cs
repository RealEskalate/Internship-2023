
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Authentication.CQRS.Commands;

public class SigninCommand : IRequest<BaseCommandResponse<SigninResponse>>
{
    public SigninFormDto SigninForm { get; set; } = null!;
}