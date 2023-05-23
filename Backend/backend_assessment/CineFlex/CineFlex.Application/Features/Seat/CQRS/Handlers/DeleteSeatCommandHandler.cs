using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSeatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

            var seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (seat == null)
            {
                response.Success = false;
                response.Message = "Seat not found.";
                return response;
            }

            await _unitOfWork.SeatRepository.Delete(seat);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Seat deleted successfully.";

            return response;
        }
    }
}
