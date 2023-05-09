using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateRateDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.RateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Rate = await _unitOfWork.RateRepository.Get(request.RateDto.Id);

                if (Rate is null)
                    return null;
                   
                _mapper.Map(request.RateDto, Rate);

                await _unitOfWork.RateRepository.Update(Rate);
              
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }    
            }

            return response;
        }
    }
}
