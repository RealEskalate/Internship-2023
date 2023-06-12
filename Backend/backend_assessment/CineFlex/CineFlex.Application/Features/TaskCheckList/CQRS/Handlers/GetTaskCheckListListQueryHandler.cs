using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class GetTaskCheckListListQueryHandler : IRequestHandler<GetTaskCheckListListQuery, BaseCommandResponse<List<TaskCheckListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskCheckListListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<TaskCheckListDto>>> Handle(GetTaskCheckListListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<TaskCheckListDto>>();
            var TaskCheckLists = await _unitOfWork.TaskCheckListRepository.GetAll();

            response.Success = true;
            response.Message = "CheckLists retrieval Successful";
            response.Value = _mapper.Map<List<TaskCheckListDto>>(TaskCheckLists);

            return response;
        }
    }
}
