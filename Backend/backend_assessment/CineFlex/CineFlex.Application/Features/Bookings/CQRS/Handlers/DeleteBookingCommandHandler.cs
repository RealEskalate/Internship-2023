using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var Booking = await _unitOfWork.BookingRepository.Get(request.Id);

            if (Booking is null)
            {
                response.Success = false;
                response.Message = "Failed find a Booking by that Id.";
            }
            else
            {

                await _unitOfWork.BookingRepository.Delete(Booking);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Booking deleted Successful";
                    response.Value = Booking.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Booking Deletion Failed";
                }
            }

            return response;
        }
    }
}
