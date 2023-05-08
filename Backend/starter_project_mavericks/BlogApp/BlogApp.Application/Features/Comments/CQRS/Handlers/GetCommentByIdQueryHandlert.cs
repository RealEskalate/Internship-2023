using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
          
             var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            return _mapper.Map<CommentDto>(comment);
        
        }
    }
}
