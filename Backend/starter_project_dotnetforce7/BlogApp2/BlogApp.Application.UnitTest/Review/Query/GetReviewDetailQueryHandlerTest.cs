using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Reviews.Query
{
    public class GetReviewDetailQueryHandlerTest
    {


      

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int Id;
        private readonly GetReviewDetailQueryHandler _handler;
        public GetReviewDetailQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            Id = 1;

            _handler = new GetReviewDetailQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetReviewDetail()
        {
            var result = await _handler.Handle(new GetReviewDetailQuery() { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<Result<ReviewDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<ReviewDto>();
        }

        [Fact]
        public async Task GetNonExistingReview()
        {

            Id = -1;
            var result = await _handler.Handle(new GetReviewDetailQuery() { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<Result<ReviewDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(null);
        }
    }
}

