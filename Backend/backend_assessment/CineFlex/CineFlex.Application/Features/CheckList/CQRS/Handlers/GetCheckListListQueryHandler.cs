using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.CheckList.CQRS.Queries;
using CineFlex.Application.Features.CheckList.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Handlers
{
    public class GetCheckListListQueryHandler : IRequestHandler<GetCheckListListQuery, BaseCommandResponse<List<CheckListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCheckListListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<CheckListDto>>> Handle(GetCheckListListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<CheckListDto>>();
            var checklist = await _unitOfWork.CheckListRepository.GetAll();

            response.Success = true;
            response.Message = "Check list retrieval Successful";
            response.Value = _mapper.Map<List<CheckListDto>>(checklist);

            return response;
        }
    }
}
