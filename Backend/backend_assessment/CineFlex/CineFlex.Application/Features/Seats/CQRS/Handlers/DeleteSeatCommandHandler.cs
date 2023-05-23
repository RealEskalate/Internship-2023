using MediatR;
using AutoMapper;
using CineFlex.Domain;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;

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
        public async Task<BaseCommandResponse<Unit>> Handle(DeleteSeatCommand command, CancellationToken cancellationToken)
        {
            
            Seat? seat = await _unitOfWork.SeatRepository.Get(command.SeatID);
            if(seat == null){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to delete seat",
                    Errors=new List<string>{"Seat with the specified ID doesnot exist"}
                };
            }
            
            await _unitOfWork.SeatRepository.Delete(seat);
            var operations = await _unitOfWork.Save();
            if(operations < 1){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to delete seat",
                    Errors=new List<string>{"Failed to save to database"}
                };
            }

            return new BaseCommandResponse<Unit>{
                Success=true,
                Message="Successfully deleted the seat"
            };
            
        }
    }
}
