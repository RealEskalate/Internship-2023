using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.CheckList.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteCheckListCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var checklist = await _unitOfWork.CheckListRepository.Get(request.Id);

            if (checklist is null)
            {
                response.Success = false;
                response.Message = "Failed find a movie by that Id.";
            }
            else
            {

                await _unitOfWork.CheckListRepository.Delete(checklist);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "check list deleted Successful";
                    response.Value = checklist.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "check list Deletion Failed";
                }
            }

            return response;
        }
    }
}
