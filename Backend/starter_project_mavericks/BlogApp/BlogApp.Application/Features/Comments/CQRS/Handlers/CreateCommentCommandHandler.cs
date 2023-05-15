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

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseResponse<Nullable<int>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Nullable<int>>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (validationResult.IsValid == false)
            {
                return new BaseResponse<Nullable<int>>
                {
                    Success = false,
                    Message = "Comment Creation Failed",
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };

            }
            else
            {
                var comment = _mapper.Map<Comment>(request.CommentDto);

                comment = await _unitOfWork.CommentRepository.Add(comment);
                bool successful = await _unitOfWork.Save() > 0;

                if (!successful)
                {
                    return new BaseResponse<Nullable<int>>
                    {
                        Success = false,
                        Message = "Comment Creation Failed",
                        Errors = new List<string>() { "Failed to save to database" }
                    };
                }
                return new BaseResponse<Nullable<int>>
                {
                    Success = true,
                    Message = "Comment Creation Success",
                    Data = comment.Id
                };


            }


        }
    }
}
