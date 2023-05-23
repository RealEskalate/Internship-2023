using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<int>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await _unitOfWork.SeatRepository.Get(request.Id);

        if (seat == null)
            return new BaseCommandResponse<int>()
            {
                Success = false,
                Message = "Seat does not exist."
            };

        await _unitOfWork.SeatRepository.Delete(seat);

        if (await _unitOfWork.Save() > 0)
            return new BaseCommandResponse<int>()
            {
                Success = true,
                Message = "Seat deleted successfully.",
                Value = seat.Id
            };

        return new BaseCommandResponse<int>()
        {
            Success = false,
            Message = "Seat deletion failed."
        };
    }
}