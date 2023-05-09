using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class GetCommentDetailQueryHandler : IRequestHandler<GetCommentDetailQuery,Result<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<CommentDto>> Handle(GetCommentDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<CommentDto>();
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<CommentDto>(comment);

            return response;
        }
    }
}
