using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateSeatDto CreateSeatDto { get; set; }
    }
}
