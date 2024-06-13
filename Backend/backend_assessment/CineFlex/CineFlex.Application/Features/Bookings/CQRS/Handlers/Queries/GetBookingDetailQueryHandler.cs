using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Queries;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Features.Bookings.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers.Queries;

public class GetBookingDetailQueryHandler: IRequestHandler<GetBookingDetailQuery, BaseCommandResponse<BookingDetailDto?>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookingDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<BookingDetailDto?>> Handle(GetBookingDetailQuery request, CancellationToken cancellationToken)
    {
        
        var response = new BaseCommandResponse<BookingDetailDto?>();
        var validator = new GetBookingDetailQueryValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Booking Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var booking = await _unitOfWork.BookingRepository.Get(request.Id);
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Value = _mapper.Map<BookingDetailDto>(booking);
        }

        return response;
    }
}