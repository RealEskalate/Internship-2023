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
using BlogApp.Application.Exceptions;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);

            if (blog is null){
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else{

                await _unitOfWork.BlogRepository.Delete(blog);


                  if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                    response.Value = blog.Id;
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
