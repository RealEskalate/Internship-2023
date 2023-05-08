using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using AutoMapper;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;

public class GetBlogDetailsQueryHandler: IRequestHandler<GetBlogDetailsQuery, Result<BlogDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBlogDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<BlogDetailsDto?>> Handle(GetBlogDetailsQuery request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.BlogRepository.Get(request.Id);
        var blogDto = _mapper.Map<BlogDetailsDto>(blog);
        return new Result<BlogDetailsDto?>() { Value = blogDto, Message = "Successful", Success = true, };
    }
}   