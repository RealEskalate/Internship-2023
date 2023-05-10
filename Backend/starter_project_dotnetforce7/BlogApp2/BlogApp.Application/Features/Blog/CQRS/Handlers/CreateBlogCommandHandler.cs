using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {

            var response = new Result<int>();
            var validator = new CreateBlogDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BlogDto);



            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var blog = _mapper.Map<Blog>(request.BlogDto);

                if (request.BlogDto.BlogTags != null && request.BlogDto.BlogTags.Any())
                {
                    foreach (var tagId in request.BlogDto.BlogTags)
                    {
                        var existingTag = await _unitOfWork.TagRepository.Get(tagId);
                        if (existingTag != null)
                        {
                            
                            blog.Tags.Add(existingTag);

                        }
                    }
                }


                blog = await _unitOfWork.BlogRepository.Add(blog);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = blog.Id;
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
