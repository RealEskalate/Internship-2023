using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Features.Seat.DTO.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();
            var validator = new UpdateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateSeatDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
           
            var seat = await _unitOfWork.SeatRepository.Get(request.updateSeatDto.Id);

            if (seat == null)
            {
              response.Success = true;
              response.Message = "no Seat found by this id";
            }
            _mapper.Map(request.updateSeatDto, seat);
            await _unitOfWork.SeatRepository.Update(seat);
            if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Successfully Updated";
                    response.Value = Unit.Value;
                }
            else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }

            return response;
        }
    }
}
