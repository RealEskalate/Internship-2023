
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers;

public class GetSeatDetailQueryHandler : IRequestHandler<GetSeatDetailQuery, BaseCommandResponse<SeatDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeatDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatDetailQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<SeatDto>();
        var seat = await _unitOfWork.SeatRepository.Get(request.Id);
        response.Success = true;
        response.Message = "seat detail retrieval Successful";
        response.Value = _mapper.Map<SeatDto>(seat);

        return response;
    }
}