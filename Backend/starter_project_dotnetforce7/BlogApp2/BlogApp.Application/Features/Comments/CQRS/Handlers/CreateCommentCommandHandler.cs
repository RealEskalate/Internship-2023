using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features._Indices.DTOs.Validators;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var comment = _mapper.Map<Comment>(request.CommentDto);

                comment = await _unitOfWork.CommentRepository.Add(comment);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = comment.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }
            }

            return response;
        }
    }
}
