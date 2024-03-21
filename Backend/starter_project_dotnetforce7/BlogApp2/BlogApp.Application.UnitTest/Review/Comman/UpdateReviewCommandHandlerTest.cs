using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Rates.Command
{
    public class UpdateReviewCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateReviewDto _reviewDto;
        private readonly UpdateReviewCommandHandler _handler;
        public UpdateReviewCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _reviewDto = new UpdateReviewDto
            {
                Id = 1,
                ReviewerId = 1,
                ReviewContent = "Nice",
                BlogId = 1,
                isResolved = true
            };

            _handler = new UpdateReviewCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateReview()
        {
            var result = await _handler.Handle(new UpdateReviewCommand() { ReviewDto = _reviewDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var review = await _mockRepo.Object.ReviewRepository.Get(_reviewDto.Id);
            review.Id.Equals(_reviewDto.Id);
            review.ReviewerId.Equals(_reviewDto.ReviewerId);
            review.ReviewContent.Equals(_reviewDto.ReviewContent);
            review.BlogId.Equals(_reviewDto.BlogId);
            review.isResolved.Equals(_reviewDto.isResolved);

        }


        [Fact]
        public async Task Update_With_Invalid_ReviewContent()
        {

            _reviewDto.ReviewContent = "";
            var result = await _handler.Handle(new UpdateReviewCommand() { ReviewDto = _reviewDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var reviews = await _mockRepo.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(3);

        }

    }
}



