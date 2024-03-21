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

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, BaseResponse<List<CommentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<CommentDto>>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.CommentRepository.GetAll();
          
            var listOfComments = _mapper.Map<List<CommentDto>>(comments);
            return new BaseResponse<List<CommentDto>>(){
                Success = true,
                Data = listOfComments
            };
        }
    }
}
