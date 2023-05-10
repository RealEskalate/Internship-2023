using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.UnitTests.Reviews
{
    public class CreateReviewCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateReviewCommandHandler _handler;

        public CreateReviewCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateReviewCommandHandler(_mapper, _mockUow.Object);
        }

        [Fact]
        public async Task ValidReviewCreationTest()
        {
            // Arrange
            var request = new CreateReviewCommand
            {
                CreateReviewDto = new CreateReviewDto
                {
                    BlogId = 1,
                    ReviewerId = 1,
                    Comment = "Nice work",
                    IsResolved = false
                }
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<int?>>();
            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(4);
        }

        [Fact]
        public async Task ValidReviewCreationWithoutResolveStatusTest()
        {
            // Arrange
            var request = new CreateReviewCommand
            {
                CreateReviewDto = new CreateReviewDto
                {
                    BlogId = 1,
                    ReviewerId = 1,
                    Comment = "Nice",
                }
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<int?>>();
            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(4);
        }

        [Fact]
        public async Task InvalidReviewCreationWithNullBlogIdTest()
        {
            // Arrange
            var request = new CreateReviewCommand
            {
                CreateReviewDto = new CreateReviewDto
                {
                    BlogId = 0,
                    ReviewerId = 0,
                    Comment = "",
                    IsResolved = false
                },
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<int?>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidReviewCreationWithEmptyCommentTest()
        {
            // Arrange
            var request = new CreateReviewCommand
            {
                CreateReviewDto = new CreateReviewDto
                {
                    BlogId = 1,
                    ReviewerId = 1,
                    Comment = "",
                },
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<int?>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidReviewCreationWithNullReviewerIdTest()
        {
            // Arrange
            var request = new CreateReviewCommand
            {
                CreateReviewDto = new CreateReviewDto
                {
                    BlogId = 0,
                    ReviewerId = 0,
                    Comment = "",
                },
            };
            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<int?>>();
            response.Success.ShouldBeFalse();

        }
    }
}

           
