using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Queries;
using BlogApp.Application.Features.BlogRates.DTOs;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Handlers
{
    public class GetBlogRateListByBlogRequestHandler : IRequestHandler<GetBlogRateListByBlogRequest, List<BlogRateDto>>

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetBlogRateListByBlogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BlogRateDto>> Handle(GetBlogRateListByBlogRequest request, CancellationToken cancellationToken)
        {

            var blogRates = await _unitOfWork.BlogRateRepository.GetBlogRatesByBlog(request.BlogId);
            var blogRateDtos = _mapper.Map<List<BlogRateDto>>(blogRates);
            return blogRateDtos;

            

        }
    }
}
