using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Commands
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var seat = await _unitOfWork.SeatRepository.Get(request.SeatId);

            if (seat is null)
            {
                response.Success = false;
                response.Message = "Failed find a seat by that Id.";
            }
            else
            {

                await _unitOfWork.SeatRepository.Delete(seat);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Seat deleted Successful";
                    response.Value = seat.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Seat Deletion Failed";
                }
            }

            return response;
        }
    }
}
