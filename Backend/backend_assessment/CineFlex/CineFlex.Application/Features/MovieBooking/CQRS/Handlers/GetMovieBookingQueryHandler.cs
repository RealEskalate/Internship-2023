using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.MovieBookings.CQRS.Queries;
using CineFlex.Application.Features.MovieBookings.DTO;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class GetMovieBookingQueryHandler : IRequestHandler<GetMovieBookingQuery, BaseCommandResponse<MovieBookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetMovieBookingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<MovieBookingDto>> Handle(GetMovieBookingQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.MovieBookingRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(MovieBookingDto), request.Id);
                return new BaseCommandResponse<MovieBookingDto>
                {
                    Success = false,
                    Message = "MovieBooking Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var MovieBooking = await _unitOfWork.MovieBookingRepository.Get(request.Id);
            return new BaseCommandResponse<MovieBookingDto>
            {
                Success = true,
                Message = "MovieBooking Fetch Success",
                Value = _mapper.Map<MovieBookingDto>(MovieBooking)
            };
        }
    }

}
