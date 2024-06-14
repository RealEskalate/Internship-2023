using MediatR;
using CineFlex.Application.Responses;
using CineFlex.Application.Features.Seats.DTOs;


namespace CineFlex.Application.Features.Seats.CQRS.Queries
{
    public class GetCinemaSeatsQuery: IRequest<BaseCommandResponse<List<SeatListDto>>>
    {   
        public int CinemaID { get; set; }
    }
}   