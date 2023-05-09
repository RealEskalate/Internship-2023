using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class PublishBlogCommandHandler : IRequestHandler<PublishBlogCommand, BaseResponse<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PublishBlogCommandHandler(IMapper mapper, IUnitOfWork work)
        {
            _mapper = mapper;
            _unitOfWork = work;
        }

        public async Task<BaseResponse<Unit>> Handle(PublishBlogCommand request, CancellationToken cancellationToken)
        {
            var Blog = await _unitOfWork.BlogRepository.Get(request.Id);
            if(Blog == null){
                var error = new NotFoundException(nameof(Blog), request.Id);
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Publishing Blog Failed",
                };
                response.Errors.Add(error.Message);
                return response;
            }

            Blog.Status = PublicationStatus.Published;
            await _unitOfWork.BlogRepository.Update(Blog);

            bool successful = await _unitOfWork.Save() > 0;

            if(!successful){
                return new BaseResponse<Unit> {
                    Success=false, 
                    Message="Publishing Blog Failed", 
                    Errors=new List<string>(){"Failed to save to database"}
                };
            }

            return new BaseResponse<Unit>(){
                Success = true,
                Message = "Blog Published Successfully",
            };
        }
    }
}