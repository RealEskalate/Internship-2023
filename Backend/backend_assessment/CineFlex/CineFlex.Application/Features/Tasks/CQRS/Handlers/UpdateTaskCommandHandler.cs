using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.DTO.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();
            var validator = new UpdateTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateTaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
           
            var Task = await _unitOfWork.TaskRepository.Get(request.updateTaskDto.Id);

            if (Task == null)
            {
              response.Success = true;
              response.Message = "no task found by this id";
            }
            _mapper.Map(request.updateTaskDto, Task);
            await _unitOfWork.TaskRepository.Update(Task);
            if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Successfully Updated";
                    response.Value = Unit.Value;
                }
            else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }

            return response;
        }
    }
}
