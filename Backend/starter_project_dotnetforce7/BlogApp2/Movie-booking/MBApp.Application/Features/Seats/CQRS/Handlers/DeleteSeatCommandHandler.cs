using AutoMapper;
using MBApp.Application.Contracts.Persistence;
using MBApp.Application.Exceptions;
using MBApp.Application.Features.Seats.CQRS.Commands;
using MBApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.CQRS.Handlers
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand,Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var Seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (Seat == null)
            {
                return null;
            }
            else
            {
                await _unitOfWork.SeatRepository.Delete(Seat);
                if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            
            }
            return response;
        }
    }
}
