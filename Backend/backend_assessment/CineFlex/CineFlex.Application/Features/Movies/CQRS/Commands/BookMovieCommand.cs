
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Commands
{
    public class BookMovieCommand : IRequest<BaseCommandResponse<int>>
    {
        public BookDto BookDto { get; set; }
    }
}