using BlogApp.Domain;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }



        public async Task<Result<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TagDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var tag = _mapper.Map<Tag>(request.TagDto);
                tag = await _unitOfWork.TagRepository.Add(tag);


                if (await _unitOfWork.Save() > 0)
                {

                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = tag.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }
            }

            return response;
        }
    }
}