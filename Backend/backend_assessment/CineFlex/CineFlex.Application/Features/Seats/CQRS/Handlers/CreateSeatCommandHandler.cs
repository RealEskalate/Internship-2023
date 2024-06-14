using MediatR;
using AutoMapper;
using CineFlex.Domain;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand command, CancellationToken cancellationToken)
        {
            
            var validator = new CreateSeatDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(command.CreateSeatDto);
            if(!validationResult.IsValid){
                return new BaseCommandResponse<int>{
                    Success=false,
                    Message="Failed to create seat",
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
            Seat newSeat = _mapper.Map<Seat>(command.CreateSeatDto);
            
            newSeat = await _unitOfWork.SeatRepository.Add(newSeat);
            var operations = await _unitOfWork.Save();
            if(operations < 1){
                return new BaseCommandResponse<int>{
                    Success=false,
                    Message="Failed to create seat",
                    Errors=new List<string>{"Failed to save to database"}
                };
            }

            return new BaseCommandResponse<int>{
                Success=true,
                Message="Successfully created a new seat",
                Value=newSeat.Id
            };
            
        }
    }
}
