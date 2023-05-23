using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers;

public class GetCinemaListQueryHandler : IRequestHandler<GetCinemaListQuery, BaseCommandResponse<List<CinemaDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCinemaListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<CinemaDto>>> Handle(GetCinemaListQuery request,
        CancellationToken cancellationToken)
    {
        var cinema = await _unitOfWork.CinemaRepository.GetAll();

        if (cinema == null || cinema.Count == 0)
            return new BaseCommandResponse<List<CinemaDto>>
            {
                Success = false,
                Message = "No Cinema found."
            };
        return new BaseCommandResponse<List<CinemaDto>>
        {
            Success = true,
            Value = _mapper.Map<List<CinemaDto>>(cinema)
        };
    }
}