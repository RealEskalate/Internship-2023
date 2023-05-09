using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Comment = await _unitOfWork.CommentRepository.Get(request.CommentDto.Id);

                if (Comment is null)
                    return null;
                   
                _mapper.Map(request.CommentDto, Comment);

                await _unitOfWork.CommentRepository.Update(Comment);
              
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }    
            }

            return response;
        }
    }
}
