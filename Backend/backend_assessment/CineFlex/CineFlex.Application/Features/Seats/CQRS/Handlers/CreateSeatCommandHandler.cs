using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
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
        var validationResult =
            await new CreateSeatDtoValidation().ValidateAsync(request.CreateSeatDto, cancellationToken);

        if (!validationResult.IsValid)
            return new BaseCommandResponse<int>
            {
                Success = false,
                Message = "Seat Creation Failed",
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };

        var seat = _mapper.Map<Seat>(request.CreateSeatDto);

        seat = await _unitOfWork.SeatRepository.Add(seat);

        var res = await _unitOfWork.Save();
        Console.Out.WriteLine(res);
        if (res > 0)
            return new BaseCommandResponse<int>
            {
                Success = true,
                Message = "Creation Successful",
                Value = seat.Id
            };

        return new BaseCommandResponse<int>
        {
            Success = false,
            Message = "Creation Failed"
        };
    }
}