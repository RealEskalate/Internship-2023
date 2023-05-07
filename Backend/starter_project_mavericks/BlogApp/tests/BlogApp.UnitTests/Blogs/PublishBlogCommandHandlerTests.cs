using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class PublishBlogCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IBlogRepository> _mockBlogRepo;
        private readonly PublishBlogCommandHandler _handler;

        public PublishBlogCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _mockBlogRepo = MockBlogRepository.GetBlogRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new PublishBlogCommandHandler(_mockBlogRepo.Object, _mapper, _mockUow.Object);
        }
        
        [Fact]
        public async Task ValidPublishBlogTest()
        {
            var response = await _handler.Handle(new PublishBlogCommand() {
                Id = 4
            }, CancellationToken.None);

            var blog = await _mockBlogRepo.Object.Get(id: 4);

            Assert.IsType<BaseResponse<Unit>>(response);
            Assert.Equal(PublicationStatus.Published, blog.Status);
            Assert.True(response.Success);            
        }

        [Fact]
        public async Task InvalidPublishBlogTest()
        {
            var response = await _handler.Handle(new PublishBlogCommand() {
                Id = 4000
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Unit>>(response);
            Assert.False(response.Success);        
        }
    }
}