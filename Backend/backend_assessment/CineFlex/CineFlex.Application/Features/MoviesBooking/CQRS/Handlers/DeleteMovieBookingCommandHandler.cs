using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.MoviesBooking.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Handlers;

    public class DeleteMovieBookingCommandHandler : IRequestHandler<DeleteMovieBookingCommand,BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMovieBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var movieBooking = await _unitOfWork.MovieBookingRepository.Get(request.Id);

            if (movieBooking is null)
            {
                response.Success = false;
                response.Message = "Failed find a movieBooking by that Id.";
            }
            else
            {

                await _unitOfWork.MovieBookingRepository.Delete(movieBooking);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Movie deleted Successful";
                    response.Value = movieBooking.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Movie Deletion Failed";
                }
            }

            return response;
        }
    }


