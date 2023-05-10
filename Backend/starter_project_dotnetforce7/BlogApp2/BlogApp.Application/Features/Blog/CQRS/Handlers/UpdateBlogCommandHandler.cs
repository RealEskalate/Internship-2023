using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Responses;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {

            var response = new Result<Unit>();


            var validator = new UpdateBlogDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BlogDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {

                var blog = await _unitOfWork.BlogRepository.Get(request.BlogDto.Id);

                if (blog == null)
                {
                    return null;
                }


                _mapper.Map(request.BlogDto, blog);

                blog.Tags = new List<Tag>();

                if (request.BlogDto.blogTags != null && request.BlogDto.blogTags.Any())
                {
                    foreach (var id in request.BlogDto.blogTags)
                    {
                        var existingTag = await _unitOfWork.TagRepository.Get(id);
                        if (existingTag != null)
                        {
                            blog.Tags.Add(existingTag);

                        }
                    }
                }


                await _unitOfWork.BlogRepository.Update(blog);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    response.Value = Unit.Value;
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
