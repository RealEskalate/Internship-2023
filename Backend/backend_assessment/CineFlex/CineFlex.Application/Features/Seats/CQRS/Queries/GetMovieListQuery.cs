using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Queries
{
    public class GetMovieListQuery : IRequest<BaseCommandResponse<List<MovieDto>>>
    {

    }
}
