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
            var validator = new CreateBlogDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BlogDto);
            Console.WriteLine("publcation: ");

            Console.WriteLine(request.BlogDto.PublicationStatus);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                Console.WriteLine("Failed Validation", response.Message);
                Console.WriteLine(response.Errors[0]);

            }
            else
            {
                var blog = _mapper.Map<Blog>(request.BlogDto);

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
                Console.WriteLine("Failed 0");

                }

            }

            return response;
        }
    }
}
