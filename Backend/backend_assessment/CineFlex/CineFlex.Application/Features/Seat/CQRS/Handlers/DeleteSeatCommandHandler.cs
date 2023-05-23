
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.DTOs.Validators;
using CineFlex.Application.Responses;
using FluentValidation;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers;

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
        var response = new BaseCommandResponse<int>();
        var validator = new DeleteSeatDtoValidator();
        var validationResult = await validator.ValidateAsync(request.baseDto);



        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        }
        else
        {
            var seat = _mapper.Map<Domain.Seat>(request.baseDto);

            await _unitOfWork.SeatRepository.Delete(seat);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Deletion Successful";
                response.Value = seat.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "Deletion Failed";
            }

        }

        return response;
    }
}
