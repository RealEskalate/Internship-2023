using MediatR;
using AutoMapper;
using BlogApp.Domain;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.DTOs.Validators;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BaseResponse<Nullable<int>>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, IUnitOfWork work)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _unitOfWork = work;
        }

        public async Task<BaseResponse<Nullable<int>>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBlogDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateBlogDTO);
            
            if(validationResult.IsValid == false){
                return new BaseResponse<Nullable<int>> {
                    Success=false, 
                    Message="Blog Creation Failed", 
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            Blog newBlog = _mapper.Map<Blog>(request.CreateBlogDTO);
            newBlog.Status = PublicationStatus.NotPublished;

            newBlog = await _blogRepository.Add(newBlog);
            await _unitOfWork.Save();
            
            return new BaseResponse<Nullable<int>> {
                Success=true, 
                Message="Blog Creation Success", 
                Data = newBlog.Id
            };
        }
    }
}