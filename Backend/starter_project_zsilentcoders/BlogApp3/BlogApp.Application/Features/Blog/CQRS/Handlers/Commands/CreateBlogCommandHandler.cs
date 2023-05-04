using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;
using Application.DTOs.Blog.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;

public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand, BaseCommandResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateBlogDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var Blog = _mapper.Map<Blog>(request.CreateBlogDto);

            Blog = await _unitOfWork._BlogRepository.Add(Blog);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = Blog.Id;
        }

        return response;
    }
}