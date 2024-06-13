using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class UpdateSeatCommand : IRequest<BaseCommandResponse<Unit>>
    {
        
        public UpdateSeatDto updateSeatDto { get; set; }
    }
}