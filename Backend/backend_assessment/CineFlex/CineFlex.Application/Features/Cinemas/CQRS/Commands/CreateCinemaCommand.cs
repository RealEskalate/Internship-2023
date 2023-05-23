using CineFlex.Application.Features.Cinemas.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinemas.CQRS.Commands
{
    public class CreateCinemaCommand:IRequest<BaseCommandResponse<int>>
    {
        public CreateCinemaDto CinemaDto { get; set; }
    }
}
