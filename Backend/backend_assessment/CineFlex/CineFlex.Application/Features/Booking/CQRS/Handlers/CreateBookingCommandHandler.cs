using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Booking.CQRS.Commands;
using CineFlex.Application.Features.Booking.DTOs.Validators;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Booking.CQRS.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateBookingDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.createBookingDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var booking = _mapper.Map<BookingEntity>(request.createBookingDto);
                booking = await _unitOfWork.BookingRepository.Add(booking);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
                    response.Value = booking.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                }

            }
            return response;
        }

    }
}
