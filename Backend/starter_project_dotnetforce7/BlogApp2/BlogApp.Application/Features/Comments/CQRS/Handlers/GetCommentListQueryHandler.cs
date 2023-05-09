using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
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

            var response = new Result<List<CommentDto>>();
            var comments = await _unitOfWork.CommentRepository.GetAll();
       
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<CommentDto>>(comments);

            return response;
        }
    }
}
