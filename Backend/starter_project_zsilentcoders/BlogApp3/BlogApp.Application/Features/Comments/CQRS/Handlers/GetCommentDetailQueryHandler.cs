using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class GetCommentDetailQueryHandler : IRequestHandler<GetCommentDetailQuery, Result<CommentDto>>
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<CommentDto?>> Handle(GetCommentDetailQuery request, CancellationToken cancellationToken)
        {

            var isComment = await _unitOfWork._CommentRepository.Exists(request.Id);
            if ( isComment){
                var comment = await _unitOfWork._CommentRepository.Get(request.Id);
                 var commentDto = _mapper.Map<CommentDto>(comment);
             
            return new Result<CommentDto?>() { Value = commentDto, Message = "Successful", Success = true, };
            }
            else{
                return new Result<CommentDto?>() { Value = null, Message = "UnSuccessful", Success = false, };
            }
           
        }

     
}
