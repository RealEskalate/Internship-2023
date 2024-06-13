using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Requests.Commands;

public class DeleteSeatCommand: IRequest<BaseCommandResponse<SeatDetailsDto?>>
{
    public int Id { get; set; }
}