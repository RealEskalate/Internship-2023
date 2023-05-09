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
using Shouldly;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class UpdateBlogCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateBlogCommandHandler _handler;

        public UpdateBlogCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateBlogCommandHandler(_mapper, _mockUow.Object);
        }
        
        [Fact]
        public async Task ValidBlogUpdateTest()
        {
            var blogUpdate = new UpdateBlogDTO{
                Id=2,
                Title="New Fifth Blog Title",
                Content="This is the updated content of the fifth blog",
                ThumbnailImageUrl="https://www.blogImages.com/new_fifthImage.jpg",    
            };
            var response = await _handler.Handle(new UpdateBlogCommand() {
                UpdateBlogDTO = blogUpdate
            }, CancellationToken.None);

            var blog = await _mockUow.Object.BlogRepository.Get(id: 2);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeTrue(); 
            blog.Title.ShouldBe(blogUpdate.Title);
            blog.Content.ShouldBe(blogUpdate.Content);
            blog.ThumbnailImageUrl.ShouldBe(blogUpdate.ThumbnailImageUrl);
        }

        [Fact]
        public async Task InvalidBlogUpdateWithInvalidIdTest()
        {
            var response = await _handler.Handle(new UpdateBlogCommand() {
                UpdateBlogDTO = new UpdateBlogDTO{
                    Id=2000,
                    Content="This is the updated content of the fifth blog",
                }
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();        
        }

        [Fact]
        public async Task InvalidBlogUpdateWithAnnulledUrlTest()
        {
            var response = await _handler.Handle(new UpdateBlogCommand() {
                UpdateBlogDTO = new UpdateBlogDTO{
                    Id = 2,
                    ThumbnailImageUrl="this is not a url",    
                }
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();       
        }

        [Fact]
        public async Task InvalidBlogUpdateWithEmptyTitleTest()
        {
            var response = await _handler.Handle(new UpdateBlogCommand() {
                UpdateBlogDTO = new UpdateBlogDTO{
                    Id=2,
                    Title="", 
                }
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();       
        }

        [Fact]
        public async Task InvalidBlogUpdateWithEmptyContentTest()
        {
            var response = await _handler.Handle(new UpdateBlogCommand() {
                UpdateBlogDTO = new UpdateBlogDTO{
                    Id=2,
                    Content="", 
                }
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();        
        }
    }
}