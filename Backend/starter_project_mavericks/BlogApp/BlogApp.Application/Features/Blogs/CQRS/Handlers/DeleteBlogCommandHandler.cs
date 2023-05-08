using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, BaseResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBlogCommandHandler(IMapper mapper, IUnitOfWork work)
        {
            _mapper = mapper;
            _unitOfWork = work;
        }   

        public async Task<BaseResponse<Unit>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var Blog = await _unitOfWork.BlogRepository.Get(request.Id);
            if(Blog == null){
                var error = new NotFoundException(nameof(Blog), request.Id);
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Blog Deletion Failed",
                };
                response.Errors.Add(error.Message);
                return response;
            }
            await _unitOfWork.BlogRepository.Delete(Blog);
            await _unitOfWork.Save();

            return new BaseResponse<Unit>(){
                Success = true,
                Message = "Blog Deleted Successfully",
            };
        }
    }
}