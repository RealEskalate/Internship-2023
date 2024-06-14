using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class BookTicketCommand: IRequest<BaseCommandResponse<int>>
    {   
        public CreateTicketDto CreateTicketDto { get; set; }
    }
}   