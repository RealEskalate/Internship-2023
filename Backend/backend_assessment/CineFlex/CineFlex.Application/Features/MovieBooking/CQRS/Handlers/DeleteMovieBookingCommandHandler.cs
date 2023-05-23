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
    public class DeleteCommandHandler: IRequestHandler<DeleteMovieBookingCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(DeleteMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

            var MovieBookings = await _unitOfWork.MovieBookingRepository.Get(request.Id);

            if (MovieBookings is null)
            {
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else
            {

                await _unitOfWork.MovieBookingRepository.Delete(MovieBookings);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                    response.Value = Unit.Value;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            }



            return response;
        }
    }
}
    

