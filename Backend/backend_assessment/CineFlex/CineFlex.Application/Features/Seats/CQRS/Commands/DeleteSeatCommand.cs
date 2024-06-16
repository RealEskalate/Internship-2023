using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Commands;

public class DeleteSeatCommand : IRequest
    {
        public int Id { get; set; }
    }