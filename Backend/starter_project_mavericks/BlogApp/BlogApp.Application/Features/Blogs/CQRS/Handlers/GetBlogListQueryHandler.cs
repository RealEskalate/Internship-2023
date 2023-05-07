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
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _blogRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IList<BlogListDTO>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Blog> blogs;
            if(request.published)
                blogs = (IReadOnlyList<Blog>)await _blogRepository.GetPublishedBlogs();
            else
                blogs = (IReadOnlyList<Blog>)await _blogRepository.GetUnPublishedBlogs();

            var blogDtos = blogs.Select(blog => _mapper.Map<BlogListDTO>(blog)).ToList();
            return new BaseResponse<IList<BlogListDTO>>(){
                Success = true,
                Data = blogDtos
            };
        }
    }
}