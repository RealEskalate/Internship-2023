using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Features.Seats.CQRS.Requests.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;

public class UpdateSeatCommandHandler: IRequestHandler<UpdateSeatCommand, BaseCommandResponse<SeatDetailsDto?>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<SeatDetailsDto?>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<SeatDetailsDto?>();
        var validator = new UpdateSeatDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateSeatDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat Update Failed"; 
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            response.Success = true;
            response.Message = "Update Successful";
            var seat = await _unitOfWork.SeatRepository.Get(request.UpdateSeatDto.Id);
            seat.Taken = request.UpdateSeatDto.Taken;
            await _unitOfWork.SeatRepository.Update(seat);
            await _unitOfWork.Save();
            response.Value = _mapper.Map<SeatDetailsDto>(seat);
        }

        return response;
    }
}