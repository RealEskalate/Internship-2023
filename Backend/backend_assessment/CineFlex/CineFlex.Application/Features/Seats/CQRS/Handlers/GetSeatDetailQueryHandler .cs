namespace CineFlex.Application.Features.Seats.CQRS.Handlers;


public class GetSeatDetailQueryHandler : IReq`sdfdsfhdsfkjfuestHandler<GetSeatDetailQuery, BaseCommandResponse<SeatDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCojhjhgjhhmmandtretertertResponse<SeatDto>> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<MovieDto>();
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Seat retrieval Successful";
            response.Value = _mapper.Map<SeatDto>(seat);

            return response;
        }
    }
