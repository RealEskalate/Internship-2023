using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers
{
    public class GetReviewDetailQueryHandler : IRequestHandler<GetReviewDetailQuery,Result<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ReviewDto>> Handle(GetReviewDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<ReviewDto>();
            var review = await _unitOfWork.ReviewRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<ReviewDto>(review);

            return response;
        }
    }
}
