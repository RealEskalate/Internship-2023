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
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PublishBlogCommandHandler(IBlogRepository repository, IMapper mapper, IUnitOfWork work)
        {
            _blogRepository = repository;
            _mapper = mapper;
            _unitOfWork = work;
        }

        public async Task<BaseResponse<Unit>> Handle(PublishBlogCommand request, CancellationToken cancellationToken)
        {
            var Blog = await _blogRepository.Get(request.Id);
            if(Blog == null){
                var error = new NotFoundException(nameof(Blog), request.Id);
                var response = new BaseResponse<Unit>{
                    Success=false, 
                    Message="Publishing blog Failed",
                };
                response.Errors.Add(error.Message);
                return response;
            }

            Blog.Status = PublicationStatus.Published;
            await _blogRepository.Update(Blog);

            await _unitOfWork.Save();

            return new BaseResponse<Unit>(){
                Success = true,
                Message = "Blog Published Successfully",
            };
        }
    }
}