using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class GetSeatsByCinemaQueryHandler : IRequestHandler<GetSeatsByCinemaQuery, BaseCommandResponse<List<SeatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSeatsByCinemaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatsByCinemaQuery request,
        CancellationToken cancellationToken)
    {
        var cinema = await _unitOfWork.CinemaRepository.Get(request.CinemaId);
        if (cinema == null)
            return new BaseCommandResponse<List<SeatDto>>
            {
                Success = false,
                Message = "Cinema does not exist."
            };

        var seats = (await _unitOfWork.SeatRepository.GetByCinemaId(request.CinemaId)).ToList();

        return new BaseCommandResponse<List<SeatDto>>
        {
            Success = true,
            Message = "Seats retrieved successfully.",
            Value = _mapper.Map<List<SeatDto>>(seats)
        };
    }
}