using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Requests.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Queries;

public class GetSeatDetailQuerysHandler: IRequestHandler<GetSeatDetailsQuery, BaseCommandResponse<SeatDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeatDetailQuerysHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<SeatDetailsDto?>> Handle(GetSeatDetailsQuery request, CancellationToken cancellationToken)
    {
        
        var response = new BaseCommandResponse<SeatDetailsDto?>();
        var validator = new GetSeatDetailsQueryValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat search Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            response.Success = true;
            response.Message = "Fetch Successful";
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            response.Value = _mapper.Map<SeatDetailsDto>(seat);
        }

        return response;
        
    }
}