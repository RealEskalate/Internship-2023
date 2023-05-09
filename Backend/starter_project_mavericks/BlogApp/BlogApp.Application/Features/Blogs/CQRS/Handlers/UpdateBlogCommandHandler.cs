using System.Net.Http.Headers;
using System.Net;
using MediatR;
using AutoMapper;
using BlogApp.Domain;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Application.Exceptions;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, BaseResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBlogCommandHandler(IMapper mapper, IUnitOfWork work)
        {
            _mapper = mapper;
            _unitOfWork = work;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBlogDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateBlogDTO);
            
            var blog = await _unitOfWork.BlogRepository.Get(request.UpdateBlogDTO.Id);

            if(validationResult.IsValid == false || blog == null){
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Blog Update Failed"
                };
                if(blog == null){
                    var error = new NotFoundException(nameof(Blog), request.UpdateBlogDTO.Id);
                    response.Errors.Add(error.Message);
                }else{
                    response.Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                }
                return response;
            }
            
            blog.Title = request.UpdateBlogDTO.Title ?? blog.Title;
            blog.Content = request.UpdateBlogDTO.Content ?? blog.Content;
            blog.ThumbnailImageUrl = request.UpdateBlogDTO.ThumbnailImageUrl ?? blog.ThumbnailImageUrl;
            
            await _unitOfWork.BlogRepository.Update(blog);
            bool successful = await _unitOfWork.Save() > 0;

            if(!successful){
                return new BaseResponse<Unit> {
                    Success=false, 
                    Message="Blog Update Failed", 
                    Errors=new List<string>(){"Failed to save to database"}
                };
            }
            
            return new BaseResponse<Unit>{
                Success=true, 
                Message="Blog Updated Successfully", 
            };
        }
    }
}