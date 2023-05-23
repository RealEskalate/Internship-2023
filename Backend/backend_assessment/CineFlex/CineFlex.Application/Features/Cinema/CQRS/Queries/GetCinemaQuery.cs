using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Queries;

public class GetCinemaQuery : IRequest<BaseCommandResponse<CinemaDto>>
{
    public int Id { get; set; }
}