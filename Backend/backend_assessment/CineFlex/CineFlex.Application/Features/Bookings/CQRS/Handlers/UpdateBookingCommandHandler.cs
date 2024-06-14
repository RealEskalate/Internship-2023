using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<Unit>();


            var validator = new UpdateBookingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookingDto);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var Booking = await _unitOfWork.BookingRepository.Get(request.BookingDto.Id);

                if (Booking == null)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    return response;
                }

                _mapper.Map(request.BookingDto, Booking);

                await _unitOfWork.BookingRepository.Update(Booking);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    response.Value = Unit.Value;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }
            }

            return response;

        }
    }
}
