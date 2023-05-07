using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Review.CQRS.Queries;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class GetReviewDetailQueryHandler : IRequestHandler<GetReviewDetailQuery, ReviewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReviewDto> Handle(GetReviewDetailQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.Get(request.Id);
            if (review == null)
                throw new NotFoundException(nameof(review), request.Id);
            return _mapper.Map<ReviewDto>(review);
        }
    }
}