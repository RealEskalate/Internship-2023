using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class GetTaskCheckListDetailQueryHandler : IRequestHandler<GetTaskCheckListDetailQuery, BaseCommandResponse<TaskCheckListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskCheckListDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<TaskCheckListDto>> Handle(GetTaskCheckListDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<TaskCheckListDto>();
            var TaskCheckList = await _unitOfWork.TaskCheckListRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Task Check List retrieval Successful";
            response.Value = _mapper.Map<TaskCheckListDto>(TaskCheckList);

            return response;
        }
    }
}
