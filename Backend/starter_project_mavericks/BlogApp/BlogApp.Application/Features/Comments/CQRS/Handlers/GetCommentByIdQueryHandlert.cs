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
using BlogApp.Application.Responses;
using BlogApp.Application.Exceptions;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery,  BaseResponse<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<BaseResponse<CommentDto>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
          
             var exists = await _unitOfWork.CommentRepository.Exists(request.Id);
          
             if(exists == false){
                var error = new NotFoundException(nameof(Comment), request.Id);
                return new BaseResponse<CommentDto> {
                    Success=false, 
                    Message="Comment Fetch Failed", 
                    Errors= new List<string>(){error.Message}
                };
            }
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            return new BaseResponse<CommentDto> {
                Success = true, 
                Message = "Comment Fetch Success", 
                Data = _mapper.Map<CommentDto>(comment)
            };
        
        
        }
    }
}
