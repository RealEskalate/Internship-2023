using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Features.BlogRates.DTOs;
using BlogApp.Application.Features.BlogRates.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Handlers
{
    public class UpdateBlogRateCommandHandler : IRequestHandler<UpdateBlogRateCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateBlogRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<Result<Unit>> Handle(UpdateBlogRateCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var validator = new BlogRateDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BlogRateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();


            }
            else
            {
                var blogRate = await _unitOfWork.BlogRateRepository.Get(request.BlogRateDto.Id);
                _mapper.Map(request.BlogRateDto, blogRate);
                await _unitOfWork.BlogRateRepository.Update(blogRate);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = new Unit();

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
