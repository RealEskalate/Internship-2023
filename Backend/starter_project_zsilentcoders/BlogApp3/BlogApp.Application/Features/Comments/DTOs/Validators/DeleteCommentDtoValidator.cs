using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.DTOs;
using FluentValidation;

namespace BlogApp.Application.Features.Blog.DTOs.Validators;

public class DeleteCommentDtoValidator: AbstractValidator<DeleteCommentDto>
{
     

    public DeleteCommentDtoValidator(IUnitOfWork  unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork._CommentRepository.Exists(id)).WithMessage($"Comment not found");
    }
}