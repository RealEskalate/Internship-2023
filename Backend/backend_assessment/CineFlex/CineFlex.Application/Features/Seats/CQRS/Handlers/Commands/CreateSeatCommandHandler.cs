using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Requests.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;

public class CreateSeatCommandHandler: IRequestHandler<CreateSeatCommand, BaseCommandResponse<int?>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<int?>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<int?>();
        var validator = new CreateSeatDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreateSeatDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Movie Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            var movie = await _unitOfWork.MovieRepository.Get(request.CreateSeatDto.Movie);
            var cinema = await _unitOfWork.CinemaRepository.Get(request.CreateSeatDto.Cinema);
            var seat = await _unitOfWork.SeatRepository.Add(new Seat()
            {
                Movie = movie,
                Cinema = cinema,
                Location = request.CreateSeatDto.Location
            });

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