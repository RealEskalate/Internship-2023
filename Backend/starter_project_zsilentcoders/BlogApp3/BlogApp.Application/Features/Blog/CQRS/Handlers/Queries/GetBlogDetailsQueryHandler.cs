using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using AutoMapper;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;

public class GetBlogDetailsQueryHandler: IRequestHandler<GetBlogDetailsQuery, BlogDetailsDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBlogDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BlogDetailDto> Handle(GetBlogDetailQuery request, CancellationToken cancellationToken)
    {
        var Blog = await _unitOfWork._BlogRepository.Get(request.Id);
        return _mapper.Map<BlogDetailDto>(Blog);
    }
}   