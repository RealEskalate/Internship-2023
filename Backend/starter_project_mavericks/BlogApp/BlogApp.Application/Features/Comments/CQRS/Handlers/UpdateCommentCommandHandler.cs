using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateCommentDto);
            
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if(validationResult.IsValid == false || comment == null){
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Comment Update Failed"
                };
                if(comment == null){
                    var error = new NotFoundException(nameof(Comment), request.Id);
                    response.Errors.Add(error.Message);
                }else{
                    response.Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                }
                return response;
            }
            
            
            _mapper.Map(request.updateCommentDto, comment);
            
            await _unitOfWork.CommentRepository.Update(comment);
            bool successful = await _unitOfWork.Save() > 0;

            if(!successful){
                return new BaseResponse<Unit> {
                    Success=false, 
                    Message="Comment Update Failed", 
                    Errors=new List<string>(){"Failed to save to database"}
                };
            }
            
            return new BaseResponse<Unit>{
                Success=true, 
                Message="Comment Updated Successfully", 
            };
        }
    }
}
