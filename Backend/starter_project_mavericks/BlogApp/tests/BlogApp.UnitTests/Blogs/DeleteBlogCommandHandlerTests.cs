using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class DeleteBlogCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IBlogRepository> _mockBlogRepo;
        private readonly DeleteBlogCommandHandler _handler;

        public DeleteBlogCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _mockBlogRepo = MockBlogRepository.GetBlogRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteBlogCommandHandler(_mapper, _mockUow.Object);
        }
        
        [Fact]
        public async Task ValidBlogDeletionTest()
        {
            var response = await _handler.Handle(new DeleteBlogCommand() {
                Id = 2
            }, CancellationToken.None);

            var blog = await _mockBlogRepo.Object.Get(id: 2);

            Assert.IsType<BaseResponse<Unit>>(response);
            Assert.True(response.Success);        
        }

        [Fact]
        public async Task InvalidBlogDeletionTest()
        {
            var response = await _handler.Handle(new DeleteBlogCommand() {
                Id = 4000
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Unit>>(response);
            Assert.False(response.Success);        
        }
    }
}