using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, BaseResponse<IList<BlogListDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IList<BlogListDTO>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Blog> blogs;
            if(request.published)
                blogs = (IReadOnlyList<Blog>)await _unitOfWork.BlogRepository.GetPublishedBlogs();
            else
                blogs = (IReadOnlyList<Blog>)await _unitOfWork.BlogRepository.GetUnPublishedBlogs();

            var blogDtos = blogs.Select(blog => _mapper.Map<BlogListDTO>(blog)).ToList();
            return new BaseResponse<IList<BlogListDTO>>(){
                Success = true,
                Data = blogDtos
            };
        }
    }
}