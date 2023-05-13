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
using BlogApp.Application.Contracts.Identity;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<List<BlogDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Result<List<BlogDto>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<List<BlogDto>>();
            var Blogs = await _unitOfWork.BlogRepository.GetAll();
            
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<BlogDto>>(Blogs);
            for (int i = 0; i < Blogs.Count; i++)
                response.Value[i].User = await _userService.GetUser(Blogs[i].CreatorId);
    
            return response;
        }
    }
}
