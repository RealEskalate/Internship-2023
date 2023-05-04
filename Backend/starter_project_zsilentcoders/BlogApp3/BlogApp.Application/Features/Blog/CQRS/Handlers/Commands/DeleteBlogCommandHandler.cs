using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Blog.Handlers.Commands;

public class DeleteBlogCommandHandler: IRequestHandler<DeleteBlogCommand, bool>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var Blog = await _unitOfWork._BlogRepository.Get(request.Id);

        if (Blog == null)
            throw new NotFoundException(nameof(Blog), request.Id);

        await _unitOfWork._BlogRepository.Delete(Blog);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}