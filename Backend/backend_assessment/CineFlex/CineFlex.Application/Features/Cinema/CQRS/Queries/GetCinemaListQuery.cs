using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Queries;

public class GetCinemaListQuery : IRequest<BaseCommandResponse<List<CinemaDto>>>
{
}