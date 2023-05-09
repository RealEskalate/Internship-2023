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
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogCommandHandler(IMapper mapper, IUnitOfWork work)
        {
            _mapper = mapper;
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

            newBlog = await _unitOfWork.BlogRepository.Add(newBlog);
            bool successful = await _unitOfWork.Save() > 0;

            if(!successful){
                return new BaseResponse<Nullable<int>> {
                    Success=false, 
                    Message="Blog Creation Failed", 
                    Errors=new List<string>(){"Failed to save to database"}
                };
            }

            return new BaseResponse<Nullable<int>> {
                Success=true, 
                Message="Blog Creation Success", 
                Data = newBlog.Id
            };
        }
    }
}