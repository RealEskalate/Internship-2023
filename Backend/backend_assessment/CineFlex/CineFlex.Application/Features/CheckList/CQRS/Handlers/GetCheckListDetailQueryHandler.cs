using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.CheckList.CQRS.Queries;
using CineFlex.Application.Features.CheckList.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Handlers
{
    public class GetCheckListDetailQueryHandler : IRequestHandler<GetCheckListDetailQuery, BaseCommandResponse<CheckListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCheckListDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<CheckListDto>> Handle(GetCheckListDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CheckListDto>();
            var checklist = await _unitOfWork.CheckListRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Check list retrieval Successful";
            response.Value = _mapper.Map<CheckListDto>(checklist);

            return response;
        }
    }
}
