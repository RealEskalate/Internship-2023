using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class DeleteTaskCheckListCommandHandler : IRequestHandler<DeleteTaskCheckListCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskCheckListCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteTaskCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var TaskCheckList = await _unitOfWork.TaskCheckListRepository.Get(request.Id);

            if (TaskCheckList is null)
            {
                response.Success = false;
                response.Message = "Failed find a check list by that Id.";
            }
            else
            {

                await _unitOfWork.TaskCheckListRepository.Delete(TaskCheckList);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Movie deleted Successful";
                    response.Value = TaskCheckList.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Movie Deletion Failed";
                }
            }

            return response;
        }
    }
}
