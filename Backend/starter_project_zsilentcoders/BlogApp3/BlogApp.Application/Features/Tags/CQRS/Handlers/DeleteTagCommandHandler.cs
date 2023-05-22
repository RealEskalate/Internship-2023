using System.ComponentModel.DataAnnotations;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using AutoMapper;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Responses;
using MediatR;

namespace Application.Features.Tags.CQRS.Handlers;

public class DeleteTagCommandHandler: IRequestHandler<DeleteTagCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();
        
        var validator = new DeleteTagDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteTagDto);
       
        if (validationResult.IsValid == true){
            var tag = await _unitOfWork.TagRepository.Get(request.DeleteTagDto.Id);
            await _unitOfWork.TagRepository.Delete(tag);
            if (await _unitOfWork.Save() > 0)
            {
                
                response.Message = "Deletion Successful!";
                response.Value = new Unit();
            }
            else
            {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
        }else{
            response.Success = false;
            response.Message = "Deletion Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        
        return response;
    }
}
