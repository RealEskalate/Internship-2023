using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Queries;

    public class GetSeatDetailQuery : IRequest<SeatDto>
    {
        public int Id { get; set; }
    }