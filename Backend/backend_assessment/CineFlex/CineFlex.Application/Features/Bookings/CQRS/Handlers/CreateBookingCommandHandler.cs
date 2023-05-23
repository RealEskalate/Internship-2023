using Application.Contracts;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class CreateBookingCommandHandler: IRequestHandler<CreateBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateBookingDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BookingDto);

         
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Booking Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var user =  _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName == _userAccessor.GetUsername());
                var cinema = await _unitOfWork.CinemaRepository.Get(request.BookingDto.CinemaId);
                var movie = await _unitOfWork.MovieRepository.Get(request.BookingDto.MovieId);
                var seats = new List<Seat>();

                foreach(int id in request.BookingDto.SeatsId)
                {
                    seats.Add(await _unitOfWork.SeatRepository.Get(id));
                }

                var Booking = _mapper.Map<Booking>(request.BookingDto);

                Booking.Owner = user;
                Booking.Cinema = cinema;
                Booking.Movie = movie;
                Booking.Seats = seats;

                Booking = await _unitOfWork.BookingRepository.Add(Booking);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = Booking.Id;
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
}
