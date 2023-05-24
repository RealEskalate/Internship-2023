using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, BaseCommandResponse<List<BookingDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<BookingDto>>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {

            var bookings = await _unitOfWork.BookingRepository.GetAll();

            if (bookings == null || bookings.Count == 0)
            {
                return new BaseCommandResponse<List<BookingDto>>
                {
                    Success = false,
                    Message = "No Cinema found."
                };
            }
            else
            {
                return new BaseCommandResponse<List<BookingDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<BookingDto>>(bookings)
                };
            }
        }
    }
    }

