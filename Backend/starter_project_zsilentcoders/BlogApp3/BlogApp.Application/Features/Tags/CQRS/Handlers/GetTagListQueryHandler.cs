using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers;

public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, Result<List<TagListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<TagListDto>>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
    {
        var tags = await _unitOfWork.TagRepository.GetAll();
        var tagList = _mapper.Map<List<TagListDto>>(tags);

        return new Result<List<TagListDto>>() { Value = tagList, Message = "Successful", Success = true, };
    }


}