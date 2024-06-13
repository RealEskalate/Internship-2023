using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Booking.CQRS.Command;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Booking.CQRS.Handler;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BaseCommandResponse<int>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    private bool CheckSeatAvailability(ICollection<Domain.Seat> seats)
    {
        // Get the list of seat numbers to check
        List<string> seatNumbers = seats.Select(s => s.SeatNumber).ToList();
        // Your code to fetch the existing booked seats from the database
        List<string> bookedSeatNumbers = GetBookedSeatNumbers();
        // Check if any of the desired seats are already booked
        bool seatsAvailable = !seatNumbers.Any(s => bookedSeatNumbers.Contains(s));
        return seatsAvailable;
    }

    private List<string> GetBookedSeatNumbers()
    {
        // Your code to fetch the existing booked seat numbers from the database
        // For this example, let's assume you have a data access layer to retrieve the booked seat numbers
        List<string> bookedSeatNumbers = _unitOfWork.SeatRepository.GetBookedSeatNumbers();

        return bookedSeatNumbers;
    }


    public async Task<BaseCommandResponse<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<int>();

        bool seatsAvailable = CheckSeatAvailability((ICollection<Domain.Seat>)_unitOfWork.SeatRepository.GetAll());

        if (!seatsAvailable)
        {
            return null;
        }else{
            var booking = _mapper.Map<Domain.Booking>(request.createBookingDto);

            booking = await _unitOfWork.BookingRepository.Add(booking);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "book Creation Successful";
                response.Value = booking.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "book Creation Failed";
            }
            return response;
        }
       
    }
}

