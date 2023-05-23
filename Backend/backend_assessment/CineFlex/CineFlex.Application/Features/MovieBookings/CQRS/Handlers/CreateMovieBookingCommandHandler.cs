using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Features.MovieBookings.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Handlers
{
    public class CreateMovieBookingCommandHandler: IRequestHandler<CreateMovieBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMovieBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateMovieBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateMovieBookingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MovieBookingDto);

            

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "MovieBooking Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

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

                var MovieBooking = _mapper.Map<MovieBooking>(request.MovieBookingDto);

                MovieBooking = await _unitOfWork.MovieBookingRepository.Add(MovieBooking);
                Seat.Available = false;
                await _unitOfWork.SeatRepository.Update(Seat);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = MovieBooking.Id;
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
