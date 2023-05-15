using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using MediatR;
using BlogApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand,BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if (comment == null)
            {
                  var error = new NotFoundException(nameof(Comment), request.Id);
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Comment Deletion Failed",
                };
                response.Errors.Add(error.Message);
                return response;
            }
               

            await _unitOfWork.CommentRepository.Delete(comment);
             bool successful = await _unitOfWork.Save() > 0;

            if(!successful){
                return new BaseResponse<Unit> {
                    Success=false, 
                    Message="Comment Deletion Failed", 
                    Errors=new List<string>(){"Failed to save to database"}
                };
            }

            return new BaseResponse<Unit>(){
                Success = true,
                Message = "Comment Deleted Successfully",
            };
           

           
        }
    }
}
