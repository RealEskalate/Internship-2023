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
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Result<int>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateBlogDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BlogDto);
          
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
                var user = await _userService.GetCurrentUser();
                if (user is not ApplicationUserDTO)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    Console.WriteLine("Failed 0");
                }
                else
                {

                    var blog = _mapper.Map<Blog>(request.BlogDto);
                    blog.CreatorId = user.Id;
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

            }
            return response;
        }
    }
}
