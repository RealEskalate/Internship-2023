using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MoviesBooking.CQRS.Queries;
using CineFlex.Application.Features.MoviesBooking.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Handlers
{
    public class GetMovieBookingListQueryHandler : IRequestHandler<GetMovieBookingListQuery, BaseCommandResponse<List<MovieBookingDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieBookingListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<MovieBookingDto>>> Handle(GetMovieBookingListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<MovieBookingDto>>();
            var movieBooking = await _unitOfWork.MovieBookingRepository.GetAll();

            response.Success = true;
            response.Message = "Movies retrieval Successful";
            response.Value = _mapper.Map<List<MovieBookingDto>>(movieBooking);

            return response;
        }
    }
}
