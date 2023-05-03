using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Blog.Handlers.Commands;

public class DeleteBlogCommandHandler: IRequestHandler<DeleteBlogCommand, bool>
{
    private IBlogRepository _blogRepository { get; set; }
    private IMapper _mapper { get; set; }

    public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteBlogDtoValidator(_blogRepository);
        
        if (!(await validator.ValidateAsync(request.DeleteBlogDto)).IsValid)
            return false;

        await _blogRepository.Delete(await _blogRepository.Get(request.DeleteBlogDto.Id));
        
        return true;
    }
}