using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteMovieBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var MovieBooking = await _unitOfWork.MovieBookingRepository.Get(request.Id);

            if (MovieBooking is null)
            {
                response.Success = false;
                response.Message = "Failed find a MovieBooking by that Id.";
            }
            else
            {

                if (MovieBooking.UserId != request.UserId && request.IsAdmin == false)
                {
                    response.Success = false;
                    response.Message = "Unauthorized request";
                    return response;
                }
                
                await _unitOfWork.MovieBookingRepository.Delete(MovieBooking);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "MovieBooking deleted Successful";
                    response.Value = MovieBooking.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "MovieBooking Deletion Failed";
                }
            }

            return response;
        }
    }
}
