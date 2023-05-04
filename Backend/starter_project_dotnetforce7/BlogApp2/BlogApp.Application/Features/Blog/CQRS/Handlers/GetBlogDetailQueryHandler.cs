using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Exceptions;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogDetailQueryHandler : IRequestHandler<GetBlogDetailQuery, BlogDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BlogDto> Handle(GetBlogDetailQuery request, CancellationToken cancellationToken)
        {
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);
            return _mapper.Map<BlogDto>(blog);
        }
    }
}
