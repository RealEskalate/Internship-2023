using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, BaseCommandResponse<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        var validationResult =
            await new UpdateSeatDtoValidation(_unitOfWork.SeatRepository).ValidateAsync(request.UpdateSeatDto,
                cancellationToken);

        if (!validationResult.IsValid)
            return new BaseCommandResponse<Unit>
            {
                Success = false,
                Message = "Seat Update Failed",
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };

        var seat = await _unitOfWork.SeatRepository.Get(request.UpdateSeatDto.Id);

        _mapper.Map(request.UpdateSeatDto, seat);

        await _unitOfWork.SeatRepository.Update(seat);

        if (await _unitOfWork.Save() > 0)
            return new BaseCommandResponse<Unit>
            {
                Success = true,
                Message = "Seat updated successfully."
            };

        return new BaseCommandResponse<Unit>
        {
            Success = false,
            Message = "Seat update failed."
        };
    }
}