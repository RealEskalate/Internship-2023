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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Rates.Command
{
    public class CreateReviewCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateReviewDto _reviewDto;
        private readonly CreateReviewCommandHandler _handler;
        public CreateReviewCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _reviewDto = new CreateReviewDto
            {
             ReviewerId = 1,
             ReviewContent = "Nice",
             BlogId = 1,
             isResolved= true
            };

            _handler = new CreateReviewCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateReview()
        {
            var result = await _handler.Handle(new CreateReviewCommand() { ReviewDto = _reviewDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var reviews = await _mockRepo.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(4);

        }

        [Fact]
        public async Task InvalidReview_Added()
        {

            _reviewDto.ReviewContent = "";
            var result = await _handler.Handle(new CreateReviewCommand() { ReviewDto = _reviewDto }, CancellationToken.None);
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var reviews = await _mockRepo.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(3);

        }
    }
}




