using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeatCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateSeatDto);
            var response = new BaseCommandResponse<Unit>();

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var seat = await _unitOfWork.SeatRepository.Get(request.UpdateSeatDto.Id);

            if (seat == null)
                throw new NotFoundException(nameof(seat), request.UpdateSeatDto.Id);

            _mapper.Map(request.UpdateSeatDto, seat);

            await _unitOfWork.SeatRepository.Update(seat);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Update Successful";
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
