using MediatR;
using AutoMapper;
using CineFlex.Domain;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, BaseCommandResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CancelBookingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(CancelBookingCommand command, CancellationToken cancellationToken)
        {
            
            Ticket? ticket = await _unitOfWork.TicketRepository.Get(command.TicketID);
            if(ticket == null){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to cancel booking",
                    Errors=new List<string>{"A booking with the specified ID doesnot exist"}
                };
            }
            
            await _unitOfWork.TicketRepository.Delete(ticket);
            var operations = await _unitOfWork.Save();
            if(operations < 1){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to cancel booking",
                    Errors=new List<string>{"Failed to save to database"}
                };
            }

            return new BaseCommandResponse<Unit>{
                Success=true,
                Message="Successfully cancelled booking"
            };
            
        }
    }
}
