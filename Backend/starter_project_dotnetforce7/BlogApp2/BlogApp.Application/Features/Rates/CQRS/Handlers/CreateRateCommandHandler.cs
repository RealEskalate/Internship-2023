using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Handlers
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateRateDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.RateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var rate = _mapper.Map<Rate>(request.RateDto);

                rate = await _unitOfWork.RateRepository.Add(rate);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = rate.Id;
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
