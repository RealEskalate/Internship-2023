using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Commands;

public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateSeatDto CreateSeatDto { get; set; }
    }