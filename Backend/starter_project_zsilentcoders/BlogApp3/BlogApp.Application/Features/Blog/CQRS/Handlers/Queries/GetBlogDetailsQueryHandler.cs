using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using AutoMapper;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;

public class GetBlogDetailsQueryHandler: IRequestHandler<GetBlogDetailsQuery, BlogDetailsDto?>
{
    private IBlogRepository _blogRepository { get; set; }
    private IMapper _mapper { get; set; }
        
    public GetBlogDetailsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<BlogDetailsDto?> Handle(GetBlogDetailsQuery request, CancellationToken cancellationToken)     
    {
        var blog = await _blogRepository.Get(request.Id);
        return blog == null ? null : _mapper.Map<BlogDetailsDto>(blog);
    }
}   