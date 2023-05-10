using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Reviews.CQRS.Command;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.Tests.Mocks;
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
    public class UpdateReviewCommandHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private UpdateReviewCommandHandler _handler { get; set; }


        public UpdateReviewCommandHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new UpdateReviewCommandHandler(_mockUnitOfWork.Object, _mapper);
        }


        [Fact]
        public async Task UpdateReviewValid()
        {

            var updateReviewDto = new ReviewDto()
            {
                Id = 2,
                Comment = "updated",
                BlogId = 5,
                ReviewerId = 5,

            };
            var review = await _mockUnitOfWork.Object.ReviewRepository.Get(2);
            bool res = await _mockUnitOfWork.Object.ReviewRepository.Exists(2);
            res.ShouldBeTrue();

            var result = await _handler.Handle(new UpdateReviewCommand() { reviewDto = updateReviewDto }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task UpdateIsResolvedTest()
        {

            var updateIsResolved = new ReviewIsApprovedDto()
            {
                Id = 1,
                IsApproved = true,

            };
            var review = await _mockUnitOfWork.Object.ReviewRepository.Get(2);
            bool res = await _mockUnitOfWork.Object.ReviewRepository.Exists(2);
            res.ShouldBeTrue();

            var result = await _handler.Handle(new UpdateReviewCommand() { reviewIsApprovedDto = updateIsResolved }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }



        [Fact]
        public async Task UpdateReviewInvalid()
        {

            var updateReviewDto = new ReviewDto()
            {
                Id = 3,
                Comment = "updated",
                BlogId = 5,
                ReviewerId = 5,

            };
            // Id is not exist
            var result =  await _handler.Handle(new UpdateReviewCommand() { reviewDto = updateReviewDto }, CancellationToken.None);
            result.Success.ShouldBeFalse();

        }
    }
}
