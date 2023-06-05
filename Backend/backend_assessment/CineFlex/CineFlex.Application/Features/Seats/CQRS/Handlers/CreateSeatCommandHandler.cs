using AutoMapper;
using CineFlex.Application.Contracts.Persistence;

using CineFlex.Application.Responses;
using CineFlex.Domain;      
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SeatDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var seat = _mapper.Map<Seat>(request.SeatDto);

                seat = await _unitOfWork.SeatRepository.Add(seat);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
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
    
       
