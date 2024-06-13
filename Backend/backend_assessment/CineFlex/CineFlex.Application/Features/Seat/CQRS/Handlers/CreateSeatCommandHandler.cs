using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers;

public class CreateSeatCommandHandler: IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<int>();
        var validator = new CreateSeatDtoValidator();
        var validationResult = await validator.ValidateAsync(request.createSeatDto);



        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Seat Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        }
        else
        {
            var seat = _mapper.Map<Domain.Seat>(request.createSeatDto);

            seat = await _unitOfWork.SeatRepository.Add(seat);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = seat.Id;
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
