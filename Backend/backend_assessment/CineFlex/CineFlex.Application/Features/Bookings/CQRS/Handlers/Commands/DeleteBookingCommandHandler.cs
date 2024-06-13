using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Features.Bookings.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers.Commands;

public class DeleteBookingCommandHandler: IRequestHandler<DeleteBookingCommand, BaseCommandResponse<BookingDetailDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<BookingDetailDto?>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<BookingDetailDto?>();
        var validator = new DeleteBookingCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Booking deletion Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var booking = await _unitOfWork.BookingRepository.Get(request.Id);
            await _unitOfWork.BookingRepository.Delete(booking);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Deletion Successful";
            response.Value = _mapper.Map<BookingDetailDto>(booking);
        }

        return response;
    }
}