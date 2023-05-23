namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSeaTCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (seat is null)
            {
                response.Success = false;
                response.Message = "Failed find a movie by that Id.";
            }
            else
            {

                await _unitOfWork.SeatRepository.Delete(seat);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Movie deleted Successful";
                    response.Value = seat.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Movie Deletion Failed";
                }
            }

            return response;
        }
    }