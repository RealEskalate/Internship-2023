using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class CreateTaskCheckListCommandHandler : IRequestHandler<CreateTaskCheckListCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateTaskCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateTaskCheckListDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TaskCheckListDto);

            

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Movie Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var TaskCheckList = _mapper.Map<TaskCheckListEntity>(request.TaskCheckListDto);

                TaskCheckList = await _unitOfWork.TaskCheckListRepository.Add(TaskCheckList);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = TaskCheckList.Id;
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
