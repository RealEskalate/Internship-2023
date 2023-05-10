using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using AutoMapper;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Queries;

public class GetTagDetailsQueryHandler: IRequestHandler<GetTagDetailsQuery, Result<TagDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTagDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<TagDetailsDto?>> Handle(GetTagDetailsQuery request, CancellationToken cancellationToken)
    {
        var tag = await _unitOfWork.TagRepository.Get(request.Id);
        var TagDto = _mapper.Map<TagDetailsDto>(tag);
        return new Result<TagDetailsDto?>() { Value = TagDto, Message = "Successful", Success = true, };
    }
}   