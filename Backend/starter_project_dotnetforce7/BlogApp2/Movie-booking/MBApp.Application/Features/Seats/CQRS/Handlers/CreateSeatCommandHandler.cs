using AutoMapper;
using MBApp.Application.Features.Seats.CQRS.Commands;
using MBApp.Application.Features.Seats.DTOs.Validators;
using MBApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SeatDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var seat = _mapper.Map<Seat>(request.SeatDto);

                seat = await _unitOfWork.SeatRepository.Add(seat);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = seat.Id;
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
