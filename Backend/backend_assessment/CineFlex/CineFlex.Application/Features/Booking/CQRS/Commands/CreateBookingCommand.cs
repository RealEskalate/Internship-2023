using CineFlex.Application.Features.Booking.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Booking.CQRS.Commands
{
    public class CreateBookingCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateBookingDto createBookingDto { get; set; }
    }
}
