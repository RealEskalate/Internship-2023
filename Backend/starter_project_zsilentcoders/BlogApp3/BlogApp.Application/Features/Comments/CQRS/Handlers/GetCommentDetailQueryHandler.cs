using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class GetCommentDetailQueryHandler : IRequestHandler<GetCommentDetailQuery, CommentDto>
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentDetailQuery request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork._CommentRepository.Get(request.Id);
            return _mapper.Map<CommentDto>(comment);
        }

     
}
