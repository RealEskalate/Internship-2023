using AutoMapper;
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
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, BaseCommandResponse<List<TaskDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<TaskDto>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {

            var Task = await _unitOfWork.TaskRepository.GetAll();

            if (Task == null || Task.Count == 0)
            {
                return new BaseCommandResponse<List<TaskDto>>
                {
                    Success = false,
                    Message = "No Task found."
                };
            }
            else
            {
                return new BaseCommandResponse<List<TaskDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<TaskDto>>(Task)
                };
            }
        }
    }
    }

