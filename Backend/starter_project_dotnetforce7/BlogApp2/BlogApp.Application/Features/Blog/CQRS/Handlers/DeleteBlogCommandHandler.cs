using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
            private readonly IPhotoAccessor _photoAccessor;


        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IPhotoAccessor photoAccessor)
        {
            _unitOfWork = unitOfWork;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<int>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            
            var blog = await _unitOfWork.BlogRepository.Get(request.Id);

            if (blog is null){
                response.Success = false;
                response.Message = "Blog with the given Id does not exist!";
            }
            else{
                
                if(blog.CoverImage != null){
                var result = await _photoAccessor.DeletePhoto(blog.CoverImage.Id);
                response.Success = false;
                response.Message = "Failed to delete blog image!";
                if(result == null) return response;
                }
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
