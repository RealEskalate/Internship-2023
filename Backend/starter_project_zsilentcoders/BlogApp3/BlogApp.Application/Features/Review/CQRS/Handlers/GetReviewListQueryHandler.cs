using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Review.CQRS.Queries;
using BlogApp.Application.Features.Review.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, List<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetAll();
            return _mapper.Map<List<ReviewDto>>(review);
        }
    }
}