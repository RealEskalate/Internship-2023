using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.MoviesBooking.CQRS.Commands;
using CineFlex.Application.Features.MoviesBooking.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Handlers;

public class CreateMovieBookingCommandHandler : IRequestHandler<CreateMovieBookingCommand, BaseCommandResponse<int>>
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
            var validationResult = await validator.ValidateAsync(request.CreateMovieBookingDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var movieBooking = _mapper.Map<MovieBooking>(request.CreateMovieBookingDto);

                movieBooking = await _unitOfWork.MovieBookingRepository.Add(movieBooking);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;
        }
    }


