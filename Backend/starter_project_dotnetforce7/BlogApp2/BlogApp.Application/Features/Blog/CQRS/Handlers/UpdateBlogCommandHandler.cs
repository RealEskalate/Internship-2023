using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using MediatR;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

         private readonly IPhotoAccessor _photoAccessor;


        public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {

            var response = new Result<Unit>();

            //  Validate the request Create Blog Dto.
            var validator = new UpdateBlogDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BlogDto);

            if (!validationResult.IsValid)
                {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
                }
            
            var blog = await _unitOfWork.BlogRepository.Get(request.BlogDto.Id);

            // Handle a non existing blog
            if (blog == null) return null;
    
            

            _mapper.Map(request.BlogDto, blog);
            
            // Check there is a New Cover Image
             if(request.BlogDto.File?.Length > 0){

                // If there is an existing Image, delete the existing image.
                 if(blog.CoverImage != null){
                var result = await _photoAccessor.DeletePhoto(blog.CoverImage.Id);

                response.Success = false;
                response.Message = "Failed to delete blog image!";
                if(result == null) return response;
                }
                // Upload the new image and save it as Cover image
                var photoUploadResult = await _photoAccessor.AddPhoto(request.BlogDto.File);
                if (photoUploadResult.Success) blog.CoverImage = photoUploadResult.Value;

                else{
                    response.Success = false;
                    response.Message = photoUploadResult.Message;
                    return response;
                    };
                }      

            // save the changes into the database.
            await _unitOfWork.BlogRepository.Update(blog);
             if (await _unitOfWork.Save() > 0)
                response.Message = "Updated Successful";
                  
            else
                {
                response.Success = false;
                response.Message = "Update Failed";
                } 
                   
            return response;
        }
    }
}
