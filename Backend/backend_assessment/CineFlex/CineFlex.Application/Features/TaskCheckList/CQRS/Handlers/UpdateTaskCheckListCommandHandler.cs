using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class UpdateTaskCheckListCommandHandler : IRequestHandler<UpdateTaskCheckListCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateTaskCheckListCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<Unit>();


            var validator = new UpdateTaskCheckListDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TaskCheckListDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var TaskCheckList = await _unitOfWork.TaskCheckListRepository.Get(request.TaskCheckListDto.Id);

                if (TaskCheckList == null)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    return response;
                }

                _mapper.Map(request.TaskCheckListDto, TaskCheckList);

                await _unitOfWork.TaskCheckListRepository.Update(TaskCheckList);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    response.Value = Unit.Value;
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
