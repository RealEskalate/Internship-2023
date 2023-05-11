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

namespace BlogApp.Application.UnitTest.Reviews.Command
{
    public class DeleteReviewCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteReviewCommandHandler _handler;
        private readonly CreateReviewDto _reviewDto;
        public DeleteReviewCommandHandlerTest()
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
                isResolved = true
            };
            _id = 1;

            _handler = new DeleteReviewCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteReview()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteReviewCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var reviews = await _mockRepo.Object.ReviewRepository.GetAll();
            reviews.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Delete_Review_Doesnt_Exist()
        {

            _id  = -1;
            var result = await _handler.Handle(new DeleteReviewCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);
        
            var reviews = await _mockRepo.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(3);

        }
    }
}



