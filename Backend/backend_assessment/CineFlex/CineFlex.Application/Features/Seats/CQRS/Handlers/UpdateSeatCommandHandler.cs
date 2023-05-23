using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
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
            var validator = new UpdateSeatDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.updateSeatDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var Seat = await _unitOfWork.SeatRepository.Get(request.updateSeatDto.Id);

            if (Seat == null)
            {
                response.Success = true;
                response.Message = "no Seat found by this id";
                return response;
            }
            _mapper.Map(request.updateSeatDto, Seat);
            await _unitOfWork.SeatRepository.Update(Seat);
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
