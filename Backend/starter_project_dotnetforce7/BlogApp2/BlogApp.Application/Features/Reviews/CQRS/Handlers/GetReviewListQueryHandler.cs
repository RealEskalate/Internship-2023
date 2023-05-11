using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;


namespace BlogApp.Application.Features.Reviews.CQRS.Handlers
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, Result<List<ReviewDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<ReviewDto>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<List<ReviewDto>>();
            var reviews = await _unitOfWork.ReviewRepository.GetAll();
       
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<ReviewDto>>(reviews);

            return response;
        }
    }
}
