using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateCommentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if (Comment is null)
                throw new NotFoundException(nameof(Comment), request.Id);

            _mapper.Map(request.updateCommentDto, Comment);

            await _unitOfWork.CommentRepository.Update(Comment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
