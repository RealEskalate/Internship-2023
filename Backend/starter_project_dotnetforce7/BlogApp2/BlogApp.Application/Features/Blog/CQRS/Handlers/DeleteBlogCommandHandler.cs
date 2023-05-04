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
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);

            if (blog is null){
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else{

                await _unitOfWork.BlogRepository.Delete(blog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = blog.Id;
            }

           

            return response;
        }
    }
}
