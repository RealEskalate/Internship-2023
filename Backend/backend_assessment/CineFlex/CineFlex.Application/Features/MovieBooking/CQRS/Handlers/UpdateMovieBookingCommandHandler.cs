using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Features.MovieBookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class UpdateMovieBookingCommandHandler : IRequestHandler<UpdateMovieBookingCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMovieBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

           
            var MovieBookings = await _unitOfWork.MovieBookingRepository.Get(request.Id);

            if (MovieBookings == null)
            {
              response.Success = true;
              response.Message = "no MovieBookings found by this id";
            }
            _mapper.Map(request.updateMovieBookingDto, MovieBookings);
            await _unitOfWork.MovieBookingRepository.Update(MovieBookings);
            if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Successfully Updated";
                    response.Value = Unit.Value;
                }
            else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }

            return response;
        }
    }
}
