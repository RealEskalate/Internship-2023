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
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogDetailQueryHandler : IRequestHandler<GetBlogDetailQuery, Result<BlogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<BlogDto>> Handle(GetBlogDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<BlogDto>();
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<BlogDto>(blog);

            return response;
        }
    }
}
