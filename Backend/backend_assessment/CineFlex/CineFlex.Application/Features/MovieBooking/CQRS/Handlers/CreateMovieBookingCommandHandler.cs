using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class CreateMovieBookingCommandHandler : IRequestHandler<CreateMovieBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMovieBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int> ();
            
            var MovieBooking = _mapper.Map<MovieBooking>(request.MovieBookingDto);

            MovieBooking = await _unitOfWork.MovieBookingRepository.Add(MovieBooking);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successfull";
                response.Value = MovieBooking.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";

            }
            return response;
        }

    }
}
    
       
