using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBooking.CQRS.Commands;
using CineFlex.Application.Features.MovieBooking.DTOs;
using CineFlex.Application.Features.MovieBooking.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.MovieBooking.CQRS.Handlers;

public class
    CreateMovieBookingCommandHandler : IRequestHandler<CreateMovieBookingCommand,
        BaseCommandResponse<MovieBookingDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMovieBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<MovieBookingDto>> Handle(CreateMovieBookingCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult =
            await new CreateMovieBookingDtoValidation(_unitOfWork).ValidateAsync(request.CreateMovieBookingDto,
                cancellationToken);

        if (!validationResult.IsValid)
            return new BaseCommandResponse<MovieBookingDto>()
            {
                Success = false,
                Message = "Validation error.",
                Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
            };


        var seats = await _unitOfWork.SeatRepository.GetSeatsWithId(request.CreateMovieBookingDto.SeatIds);
        
        // TODO: improve this performance and make it transactional
        foreach (var seat in seats)
        {
            foreach (var booking in seat.MovieBookings)
            {
                if (booking.MovieId == request.CreateMovieBookingDto.MovieId)
                    return new BaseCommandResponse<MovieBookingDto>()
                    {
                        Success = false,
                        Message = $"Seat {seat.Id} is on hold."
                    };
            }
        }

        var movieBooking = new Domain.MovieBooking()
        {
            CinemaId = request.CreateMovieBookingDto.CinemaId,
            MovieId = request.CreateMovieBookingDto.MovieId,
            Seats = new List<Seat>(),
            UserId = request.UserId
        };

        foreach (var seat in seats)
        {
            movieBooking.Seats.Add(seat);
        }

        movieBooking = await _unitOfWork.MovieBookingRepository.Add(movieBooking);

        if (await _unitOfWork.Save() > 0)
            return new BaseCommandResponse<MovieBookingDto>()
            {
                Success = true,
                Value = _mapper.Map<MovieBookingDto>(movieBooking)
            };

        return new BaseCommandResponse<MovieBookingDto>()
        {
            Success = false,
            Message = "Movie booking failed"
        };
    }
}