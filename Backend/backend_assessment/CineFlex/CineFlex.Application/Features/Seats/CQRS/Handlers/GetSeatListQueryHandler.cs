namespace CineFlex.Application.Features.Seats.CQRS.Handlers;


 public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, BaseCommandResponse<List<SeatDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<SeatDto>>();
            var seats = await _unitOfWork.MovieRepository.GetAll();

            response.Success = true;
            response.Message = "Seats retrieval Successful";
            response.Value = _mapper.Map<List<SeatDto>>(seats);

            return response;
        }
    }
