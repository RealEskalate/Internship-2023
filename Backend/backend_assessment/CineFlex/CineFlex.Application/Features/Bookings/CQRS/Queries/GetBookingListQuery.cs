using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Queries
{
    public class GetBookingListQuery : IRequest<BaseCommandResponse<List<BookingDto>>>
    {

    }
}
