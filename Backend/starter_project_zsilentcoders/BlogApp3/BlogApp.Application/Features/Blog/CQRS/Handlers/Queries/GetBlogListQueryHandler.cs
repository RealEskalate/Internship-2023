using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;

public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<List<BlogListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<BlogListDto>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _unitOfWork.BlogRepository.GetAll();
        var blogList = _mapper.Map<List<BlogListDto>>(blogs);

        return new Result<List<BlogListDto>>() { Value = blogList, Message = "Successful", Success = true, };
    }


}