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
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSeatCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<Unit>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<Unit>();


            var seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (seat == null)
                throw new NotFoundException(nameof(seat), request.Id);

            await _unitOfWork.SeatRepository.Delete(seat);


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