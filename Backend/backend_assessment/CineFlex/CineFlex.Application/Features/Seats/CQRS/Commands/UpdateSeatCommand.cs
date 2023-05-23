using CineFlex.Application.Features.Seats.DTOs;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Commands;

 public class UpdateSeatCommand : IRequest<Unit>
    {
        public UpdateSeatDto UpdateSeatDto { get; set; }

    }