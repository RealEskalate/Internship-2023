using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, BaseResponse<IList<BlogListDTO>>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetAllBlogsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _blogRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IList<BlogListDTO>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Blog> blogs = await _blogRepository.GetAll();
            var blogDtos = blogs.Select(blog => _mapper.Map<BlogListDTO>(blog)).ToList();
            return new BaseResponse<IList<BlogListDTO>>(){
                Success = true,
                Data = blogDtos
            };
        }
    }
}