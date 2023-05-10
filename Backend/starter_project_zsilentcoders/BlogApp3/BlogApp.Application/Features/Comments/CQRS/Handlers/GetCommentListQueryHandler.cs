using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, Result<List<CommentDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<CommentDto>>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork._CommentRepository.GetAll();
           
            var commentList =  _mapper.Map<List<CommentDto>>(comment);

        return new Result<List<CommentDto>>() { Value = commentList, Message = "Successful", Success = true, };
        }
}
