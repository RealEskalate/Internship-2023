using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;
using Application.DTOs.Blog.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;

public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand, Result<BlogDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<BlogDetailsDto?>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<BlogDetailsDto?>();
        
        var validator = new CreateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateBlogDto);
       
        if (validationResult.IsValid == true){
            var blog = _mapper.Map<Domain.Blog>(request.CreateBlogDto);
            blog = await _unitOfWork.BlogRepository.Add(blog);
            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<BlogDetailsDto>(blog);
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
        }
        else
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
      
        return response;
    }
}