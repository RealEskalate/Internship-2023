using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Features.BlogRates.DTOs;
using BlogApp.Application.Features.BlogRates.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Handlers
{
    public class CreateBlogRateCommandHandler : IRequestHandler<CreateBlogRateCommand, Result<CreateBlogRateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }
        public async Task<Result<CreateBlogRateDto>> Handle(CreateBlogRateCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<CreateBlogRateDto>();
            var validator = new CreateBlogRateDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateBlogRateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();


            }
            else
            {
                var blogRate= _mapper.Map<BlogRate>(request.CreateBlogRateDto);

                blogRate = await _unitOfWork.BlogRateRepository.Add(blogRate);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = _mapper.Map<CreateBlogRateDto>(blogRate);

                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                }
                

            }
              
     
            return response;
        }
    }
}
