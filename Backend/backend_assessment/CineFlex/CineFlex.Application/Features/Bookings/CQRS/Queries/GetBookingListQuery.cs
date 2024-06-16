using CineFlex.Application.Features.Bookings.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Queries
{
    public class GetBookingListQuery :IRequest<BaseCommandResponse<List<BookingDto>>>
    {

    }
}
