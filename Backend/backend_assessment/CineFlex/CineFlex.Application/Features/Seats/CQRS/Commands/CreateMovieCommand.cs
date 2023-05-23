using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Commands
{
    public class CreateMovieCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateMovieDto MovieDto { get; set; }
    }
}
