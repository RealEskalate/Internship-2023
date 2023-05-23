using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Features.Bookings.DTOs.Validators;
using CineFlex.Application.Features.Seats.CQRS.Requests.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers;

public class CreateBookingCommandHandler: IRequestHandler<CreateBookingCommand, BaseCommandResponse<BookingDetailDto?>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<BookingDetailDto?>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<BookingDetailDto?>();
        var validator = new CreateBookingDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreateBookingDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Booking Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var seat = await _unitOfWork.SeatRepository.Get(request.CreateBookingDto.Seat);
            seat.Taken = true;
            var booking = await _unitOfWork.BookingRepository.Add(new Booking()
            {
                Seat = seat
            });
            
            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<BookingDetailDto>(booking);
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
            }

        }

        return response;
    }
    
  
}