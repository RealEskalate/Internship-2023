using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.CQRS.Queries
{
	public class GetSeatDetailQuery : IRequest<Result<SeatDto>>
	{
		public int Id { get; set; }
	}
}
