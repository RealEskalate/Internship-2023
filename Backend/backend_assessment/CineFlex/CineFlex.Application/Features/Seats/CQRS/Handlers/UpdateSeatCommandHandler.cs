using MediatR;
using AutoMapper;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Domain;

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
        public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSeatDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(command.UpdateSeatDto);
            if(!validationResult.IsValid){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to update seat",
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            Seat? seat = await _unitOfWork.SeatRepository.Get(command.UpdateSeatDto.Id);
            
            _mapper.Map(command.UpdateSeatDto, seat);

            await _unitOfWork.SeatRepository.Update(seat);
            
            var operations = await _unitOfWork.Save();
            if(operations < 1){
                return new BaseCommandResponse<Unit>{
                    Success=false,
                    Message="Failed to update seat",
                    Errors=new List<string>{"Failed to save to database"}
                };
            }

            return new BaseCommandResponse<Unit>{
                Success=true,
                Message="Successfully updated seat",
            };
            
        }
    }
}