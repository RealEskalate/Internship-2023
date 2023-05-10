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
    public class CreateBlogRateCommandHandler : IRequestHandler<CreateBlogRateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }
        public async Task<BaseCommandResponse> Handle(CreateBlogRateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBlogRateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateBlogRateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();


            }
            else
            {
                var blogRate = _mapper.Map<BlogRate>(request.CreateBlogRateDto);
                blogRate = await _unitOfWork.BlogRateRepository.Add(blogRate);
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = blogRate.Id;

            }
              
     
            return response;
        }
    }
}
