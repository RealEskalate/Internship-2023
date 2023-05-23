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

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var Seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (Seat is null)
            {
                response.Success = false;
                response.Message = "Failed to find a Seat by that Id.";
            }
            else
            {

                await _unitOfWork.SeatRepository.Delete(Seat);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Seat deleted Successful";
                    response.Value = Seat.Id;
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
