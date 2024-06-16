using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Commands;

public class CreateMovieCommand : IRequest<BaseCommandResponse<int>>
{
    public CreateMovieDto MovieDto { get; set; }
}