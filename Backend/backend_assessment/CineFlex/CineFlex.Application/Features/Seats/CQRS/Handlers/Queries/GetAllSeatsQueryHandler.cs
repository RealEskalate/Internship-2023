using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Requests.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Queries;

public class GetAllSeatsQueryHandler: IRequestHandler<GetAllSeatsQuery, BaseCommandResponse<List<SeatDetailsDto>?>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSeatsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<List<SeatDetailsDto>?>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
    {
        
        var response = new BaseCommandResponse<List<SeatDetailsDto>?>();
        var validator = new GetAllSeatsDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.GetAllSeatsDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat Fetching Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var seats = await _unitOfWork.SeatRepository.GetAll(request.GetAllSeatsDto.Movie, request.GetAllSeatsDto.Cinema);

            response.Success = true;
            response.Message = "Fetch Successful";
            response.Value = _mapper.Map<List<SeatDetailsDto>>(seats);
        }

        return response;
    }
}