using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Features.MovieBookings.DTOs.Validators;
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


            var validator = new UpdateMovieBookingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MovieBookingDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var Seat = await _unitOfWork.SeatRepository.Get(request.MovieBookingDto.SeatId);
                if(Seat.Available == false)
                {
                    response.Success = false;
                    response.Message = "MovieBooking Creation Failed";
                    response.Errors.Add("The seat is Already taken");

                    return response;
                }

                var MovieBooking = await _unitOfWork.MovieBookingRepository.Get(request.MovieBookingDto.Id);

                if (MovieBooking == null)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    return response;
                }

                _mapper.Map(request.MovieBookingDto, MovieBooking);

                await _unitOfWork.MovieBookingRepository.Update(MovieBooking);
                Seat.Available = true;
                await _unitOfWork.SeatRepository.Update(Seat);
                
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
