using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Commands
{
    public class DeleteBookingCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
