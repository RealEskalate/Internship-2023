using BlogApp.Application.Contracts.Persistence;
using FluentValidation;

namespace BlogApp.Application.Features.Tags.DTOs.Validators;

public class DeleteTagDtoValidator: AbstractValidator<DeleteTagDto>
{
    private ITagRepository _tagRepository;

    public DeleteTagDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.TagRepository.Exists(id)).WithMessage($"Tag not found");
    }
}