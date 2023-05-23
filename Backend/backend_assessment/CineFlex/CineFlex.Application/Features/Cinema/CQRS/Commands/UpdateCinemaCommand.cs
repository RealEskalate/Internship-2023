using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Commands
{
    public class UpdateCinemaCommand:IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateCinemaDto updateCinemaDto { get; set; }
    }
}
