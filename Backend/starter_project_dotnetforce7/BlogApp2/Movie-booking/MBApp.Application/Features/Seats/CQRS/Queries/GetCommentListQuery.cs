using MBApp.Application.Features.Seats.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBApp.Application.Responses;

namespace MBApp.Application.Features.Seats.CQRS.Queries
{
    public class GetSeatListQuery: IRequest<Result<List<SeatDto>>>
    {
    }
}
