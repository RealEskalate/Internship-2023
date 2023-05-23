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
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var seat = _mapper.Map<Seats>(request.SeatDto);

            seat = await _unitOfWork.SeatRepository.Add(seat);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Seat created successfully.";
                response.Value = seat.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "Seat creation failed.";
            }

            return response;
        }
    }
}
