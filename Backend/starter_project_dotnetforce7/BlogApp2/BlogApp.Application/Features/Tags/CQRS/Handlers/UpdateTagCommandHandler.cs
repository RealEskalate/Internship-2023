
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }


        public async Task<Result<Unit>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TagDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failded";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {

                var tag = await _unitOfWork.TagRepository.Get(request.TagDto.Id);

                if (tag is null)
                    return null;

                _mapper.Map(request.TagDto, tag);

                await _unitOfWork.TagRepository.Update(tag);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Update Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }

            }
            return response;


        }
    }
}