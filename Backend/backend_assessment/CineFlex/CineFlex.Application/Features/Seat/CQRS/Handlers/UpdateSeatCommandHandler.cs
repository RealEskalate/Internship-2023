using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, BaseCommandResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

            var seat = await _unitOfWork.SeatRepository.Get(request.updateSeatDto.Id);

            if (seat == null)
            {
                response.Success = false;
                response.Message = "Seat not found.";
                return response;
            }

            _mapper.Map(request.updateSeatDto, seat);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Seat updated successfully.";

            return response;
        }
    }
}
