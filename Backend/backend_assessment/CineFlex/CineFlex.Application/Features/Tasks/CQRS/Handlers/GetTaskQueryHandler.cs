using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, BaseCommandResponse<TaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetTaskQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<TaskDto>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.TaskRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Cinema), request.Id);
                return new BaseCommandResponse<TaskDto>
                {
                    Success = false,
                    Message = "Task Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var Task = await _unitOfWork.TaskRepository.Get(request.Id);
            return new BaseCommandResponse<TaskDto>
            {
                Success = true,
                Message = "Task Fetch Success",
                Value = _mapper.Map<TaskDto>(Task)
            };
        }
       
       
    }

}
