using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using Moq;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class CreateBlogCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IBlogRepository> _mockBlogRepo;
        private readonly CreateBlogCommandHandler _handler;

        public CreateBlogCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _mockBlogRepo = MockBlogRepository.GetBlogRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateBlogCommandHandler(_mockBlogRepo.Object, _mapper, _mockUow.Object);
        }
        
        [Fact]
        public async Task ValidBlogCreationTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title="Fifth Blog",
                    Content="This is the content of the fifth blog",
                    ThumbnailImageUrl="https://www.blogImages.com/fifthImage.jpg",    
                }
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task ValidBlogCreationWithNoThumbnailUrlTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title="Fifth Blog",
                    Content="This is the content of the fifth blog",
                }
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task InvalidBlogCreationWithAnnulledUrlTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title = "This is an invalid blog",
                    Content = "This is the content of an invalid blog",
                    ThumbnailImageUrl = "invalid url"
                },
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.False(response.Success);
        }

        [Fact]
        public async Task InvalidBlogCreationWithEmptyTitleTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title = "",
                    Content = "This is the content of an invalid blog",
                    ThumbnailImageUrl = "https://www.blogImages.com/fifthImage.jpg"
                },
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.False(response.Success);
        }

        [Fact]
        public async Task InvalidBlogCreationWithEmptyContentTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title = "This is an invalid blog",
                    Content = "",
                    ThumbnailImageUrl = "https://www.blogImages.com/fifthImage.jpg"
                },
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.False(response.Success);
        }
        
        [Fact]
        public async Task InvalidBlogCreationWithNullTitleTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Content = "This is the content of an invalid blog",
                    ThumbnailImageUrl = "https://www.blogImages.com/fifthImage.jpg"
                },
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.False(response.Success);        
        }

        [Fact]
        public async Task InvalidBlogCreationWithNullContentTest()
        {
            var response = await _handler.Handle(new CreateBlogCommand() {
                CreateBlogDTO = new CreateBlogDTO{
                    Title = "This is an invalid blog",
                    ThumbnailImageUrl = "https://www.blogImages.com/fifthImage.jpg"
                },
            }, CancellationToken.None);
            
            Assert.IsType<BaseResponse<Nullable<int>>>(response);
            Assert.False(response.Success);        
        }
    }
}