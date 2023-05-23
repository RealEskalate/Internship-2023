using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateSeatDto);
            var response = new BaseCommandResponse<int>();

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var seat= _mapper.Map<Seat>(request.CreateSeatDto);

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

            return response;
            

        }
    }
}
