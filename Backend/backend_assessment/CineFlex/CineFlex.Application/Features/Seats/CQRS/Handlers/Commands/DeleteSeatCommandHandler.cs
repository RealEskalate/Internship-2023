using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Requests.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;

public class DeleteSeatCommandHandler: IRequestHandler<DeleteSeatCommand, BaseCommandResponse<SeatDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<SeatDetailsDto?>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        
        var response = new BaseCommandResponse<SeatDetailsDto?>();
        var validator = new DeleteSeatCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat Delete Failed"; 
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            response.Success = true;
            response.Message = "Delete Successful";
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            await _unitOfWork.SeatRepository.Delete(seat);
            response.Value = _mapper.Map<SeatDetailsDto>(seat);
        }

        return response;
    }
}