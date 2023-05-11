using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class UpdateReviewCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateReviewCommandHandler _handler;

        public UpdateReviewCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateReviewCommandHandler(_mapper, _mockUow.Object);
        }

        [Fact]
        public async Task ValidReviewUpdateTest()
        {
            var reviewUpdate = new UpdateReviewDto()
            {
                Id = 1,
                Comment = "Nice job",
                IsResolved = true
            };

            var response = await _handler.Handle(new UpdateReviewCommand()
            {
                UpdateReviewDto = reviewUpdate
            }, CancellationToken.None);

            var review = await _mockUow.Object.ReviewRepository.GetReviewDetail(Id: 1);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            review.Comment.ShouldBe(reviewUpdate.Comment);
            review.IsResolved.ShouldBe(reviewUpdate.IsResolved);
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InvalidReviewUpdateWithInvalidIdTest()
        {
            var response = await _handler.Handle(new UpdateReviewCommand()
            {
                UpdateReviewDto = new UpdateReviewDto()
                {
                    Id = 2000,
                    Comment = "This blog is not for mediocre",
                    IsResolved = false
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidReviewUpdateWithNullTest()
        {
            var response = await _handler.Handle(new UpdateReviewCommand()
            {
                UpdateReviewDto = new UpdateReviewDto()
                {
                    Id = 2,
                    Comment = null,
                    IsResolved = true
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidReviewUpdateWithEmptyCommentTest()
        {
            var response = await _handler.Handle(new UpdateReviewCommand()
            {
                UpdateReviewDto = new UpdateReviewDto()
                {
                    Id = 2,
                    Comment = "",
                    IsResolved = false
                }
            }, CancellationToken.None);
        }
    }
}
           
