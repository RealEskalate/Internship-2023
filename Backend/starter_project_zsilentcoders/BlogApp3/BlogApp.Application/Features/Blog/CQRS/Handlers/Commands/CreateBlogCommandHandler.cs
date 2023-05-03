using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using Application.DTOs.Blog.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;

public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand, BlogDetailsDto>
{
    private IBlogRepository _blogRepository { get; set; }
    private IMapper _mapper { get; set; }

    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<BlogDetailsDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBlogDtoValidator();
        
        if (!(await validator.ValidateAsync(request.CreateBlogDto)).IsValid)
            return null;
        
        var result =  _mapper.Map<BlogDetailsDto>(await _blogRepository.Add(_mapper.Map<BlogApp.Domain.Blog>(request.CreateBlogDto)));
        return result;
    }
}