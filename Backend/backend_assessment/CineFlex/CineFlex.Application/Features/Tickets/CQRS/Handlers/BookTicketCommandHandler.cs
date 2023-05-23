using MediatR;
using AutoMapper;
using CineFlex.Domain;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class BookTicketCommandHandler : IRequestHandler<BookTicketCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookTicketCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<int>> Handle(BookTicketCommand command, CancellationToken cancellationToken)
        {
            
            var validator = new CreateTicketDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(command.CreateTicketDto);
            if(!validationResult.IsValid){
                return new BaseCommandResponse<int>{
                    Success=false,
                    Message="Failed to book a ticket",
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
            Ticket ticket = _mapper.Map<Ticket>(command.CreateTicketDto);
            
            ticket = await _unitOfWork.TicketRepository.Add(ticket);
            var operations = await _unitOfWork.Save();
            if(operations < 1){
                return new BaseCommandResponse<int>{
                    Success=false,
                    Message="Failed to book a ticket",
                    Errors=new List<string>{"Failed to save to database"}
                };
            }

            return new BaseCommandResponse<int>{
                Success=true,
                Message="Successfully booked a ticket",
                Value=ticket.Id
            };
            
        }
    }
}
