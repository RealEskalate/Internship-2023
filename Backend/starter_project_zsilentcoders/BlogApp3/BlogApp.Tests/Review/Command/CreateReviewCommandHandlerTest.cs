using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Reviews.CQRS.Command;
using BlogApp.Application.Features.Reviews.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.Tests.Reviews.Command
{
    public class CreateReviewCommandHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private CreateReviewCommandHandler _handler { get; set; }


        public CreateReviewCommandHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new CreateReviewCommandHandler(_mockUnitOfWork.Object, _mapper);
        }


        [Fact]
        public async Task CreateReviewValid()
        {

            var createReviewDto = new ReviewDto()
            {
                Id = 5,
                Comment = "With id 5",
                BlogId = 5,
                ReviewerId = 5,
                
            };

            var result = await _handler.Handle(new CreateReviewCommand() { reviewDto = createReviewDto }, CancellationToken.None);

            // should get the current review
            var review = await _mockUnitOfWork.Object.ReviewRepository.Get(5);
            review.ShouldNotBeNull();
            review.Comment.Equals("With id 5");

            // return type should be reviewDt
            result.ShouldBeOfType<Result<ReviewDto>>();

            // the count should be 3 because there are 2 that are already added
            var reviews = await _mockUnitOfWork.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(3);
        }

        [Fact]
        public async Task CreateReviewInvalid()
        {

            var createReviewDto = new ReviewDto()
            {
                Id= 10,
                Comment = "", // Blog Id is not given
                ReviewerId = 1,
            };

            var response = await _handler.Handle(new CreateReviewCommand() { reviewDto = createReviewDto }, CancellationToken.None);
            // response.Value();
            // review should be false because Blog Id should not be null
            var review = await _mockUnitOfWork.Object.ReviewRepository.Exists(10);
            review.ShouldBe(false);


            var reviews = await _mockUnitOfWork.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(2);

        }
    }
}
