using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand,Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var Comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if (Comment == null)
            {
                return null;
            }
            else
            {
                await _unitOfWork.CommentRepository.Delete(Comment);
                if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            
            }
            return response;
        }
    }
}
