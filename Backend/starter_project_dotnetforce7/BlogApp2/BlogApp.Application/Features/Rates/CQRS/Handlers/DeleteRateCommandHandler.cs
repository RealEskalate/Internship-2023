using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand,Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var Rate = await _unitOfWork.RateRepository.Get(request.Id);

            if (Rate == null)
            {
                return null;
            }
            else
            {
                await _unitOfWork.RateRepository.Delete(Rate);
                if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            
            }
            return response;
        }
    }
}
