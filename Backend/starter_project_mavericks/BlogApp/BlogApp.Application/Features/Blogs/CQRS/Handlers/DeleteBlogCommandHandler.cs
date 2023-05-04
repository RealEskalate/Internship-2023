using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
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
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBlogCommandHandler(IBlogRepository repository, IMapper mapper, IUnitOfWork work)
        {
            _blogRepository = repository;
            _mapper = mapper;
            _unitOfWork = work;
        }

        public async Task<BaseResponse<Unit>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var Blog = await _blogRepository.Get(request.Id);
            await _blogRepository.Delete(Blog);
            await _unitOfWork.Save();

            return new BaseResponse<Unit>(){
                Success = true,
                Message = "Blog Deleted Successfully",
            };
        }
    }
}