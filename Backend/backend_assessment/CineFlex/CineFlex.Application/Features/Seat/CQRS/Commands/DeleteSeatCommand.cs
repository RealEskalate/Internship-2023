using CineFlex.Application.Features.Common;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Commands;

public class DeleteSeatCommand : IRequest<BaseCommandResponse<int>>
{
    public BaseDto baseDto {get;set;}
}