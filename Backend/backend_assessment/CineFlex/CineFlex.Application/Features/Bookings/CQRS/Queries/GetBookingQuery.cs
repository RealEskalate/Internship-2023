using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Queries
{
    public class GetBookingQuery: IRequest<BaseCommandResponse<BookingDto>>
    {
        public int Id { get; set; }
    }
}
