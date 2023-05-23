using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Queries;
using CineFlex.Application.Features.MovieBookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
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

            var MovieBooking = await _unitOfWork.MovieBookingRepository.GetAll();

            if (MovieBooking == null)
            {
                return new BaseCommandResponse<List<MovieBookingDto>>
                {
                    Success = false,
                    Message = "No MovieBooking found."
                };
            }
            else
            {
                return new BaseCommandResponse<List<MovieBookingDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<MovieBookingDto>>(MovieBooking)
                };
            }
        }
    }
    }

