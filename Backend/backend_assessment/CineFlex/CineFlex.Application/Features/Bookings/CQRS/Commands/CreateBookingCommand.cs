using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Commands
{
    public class CreateBookingCommand:IRequest<BaseCommandResponse<int>>
    {
        public CreateBookingDto BookingDto { get; set; }
    }
}
