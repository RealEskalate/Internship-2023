using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Queries;
using CineFlex.Application.Features.MovieBookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class GetMovieBookingDetailQueryHandler : IRequestHandler<GetMovieBookingDetailQuery, BaseCommandResponse<MovieBookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieBookingDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<MovieBookingDto>> Handle(GetMovieBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<MovieBookingDto>();
            var MovieBooking = await _unitOfWork.MovieBookingRepository.Get(request.Id);
            response.Success = true;
            response.Message = "MovieBooking retrieval Successful";
            response.Value = _mapper.Map<MovieBookingDto>(MovieBooking);

            return response;
        }
    }
}
