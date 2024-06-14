using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.CheckList.CQRS.Commands;
using CineFlex.Application.Features.CheckList.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Handlers
{
    public class CreateCheckListCommandHandler: IRequestHandler<CreateCheckListCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateCheckListDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CheckListDto);

            

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var checklist = _mapper.Map<Domain.CheckList>(request.CheckListDto);

                checklist = await _unitOfWork.CheckListRepository.Add(checklist);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = checklist.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }

            }

            return response;
        }
    }
}
