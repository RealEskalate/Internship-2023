using System.Net.Cache;
using MediatR;
using AutoMapper;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Exceptions;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BaseResponse<BlogDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<BlogDTO>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.BlogRepository.Exists(request.Id);
            if(exists == false){
                var error = new NotFoundException(nameof(Blog), request.Id);
                return new BaseResponse<BlogDTO> {
                    Success=false, 
                    Message="Blog Fetch Failed", 
                    Errors= new List<string>(){error.Message}
                };
            }
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);
            return new BaseResponse<BlogDTO> {
                Success = true, 
                Message = "Blog Fetch Success", 
                Data = _mapper.Map<BlogDTO>(blog)
            };
        }
    }
}