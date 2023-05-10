using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         private readonly IPhotoAccessor _photoAccessor;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
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

                return response;
            }

                var blog = _mapper.Map<Blog>(request.BlogDto);

            if(request.BlogDto.File?.Length > 0){
                var photoUploadResult = await _photoAccessor.AddPhoto(request.BlogDto.File);
                if (photoUploadResult.Success && photoUploadResult.Value != null)
                    blog.CoverImage = photoUploadResult.Value;
                else{
                    response.Success = false;
                    response.Message = photoUploadResult.Message;
                    return response;
                };
            }                
            
            blog = await _unitOfWork.BlogRepository.Add(blog);
                if (await _unitOfWork.Save() > 0)
            {

                response.Message = "Creation Successful";
                response.Value = blog.Id;
            }
            else
            {

                response.Success = false;
                response.Message = "Creation Failed";

            }
            return response;
        }
    }
}
