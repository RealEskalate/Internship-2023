using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Features.Comments.DTOs;

using FluentValidation;
using BlogApp.Application.Contracts.Persistence;

namespace BlogApp.Application.Features.Comments.DTOs.Validators;


public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator(IUnitOfWork unitOfWork)
    {
         
       RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork._CommentRepository.Exists(id)).WithMessage($"Comment not found");
    }
}
