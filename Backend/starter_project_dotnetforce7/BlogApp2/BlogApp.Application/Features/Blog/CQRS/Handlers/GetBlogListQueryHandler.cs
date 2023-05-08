using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<List<BlogDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<BlogDto>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<List<BlogDto>>();
            var Blogs = await _unitOfWork.BlogRepository.GetAll();
            
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<BlogDto>>(Blogs);

            return response;
        }
    }
}
