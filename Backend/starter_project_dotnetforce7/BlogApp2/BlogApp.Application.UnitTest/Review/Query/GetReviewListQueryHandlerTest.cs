using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
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
    public class GetReviewListQueryHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetReviewListQueryHandler _handler;
        public GetReviewListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetReviewListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetReviewList()
        {
            var result = await _handler.Handle(new GetReviewListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<ReviewDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<List<ReviewDto>>(); 
            result.Value.Count.ShouldBe(3);
        }
    }
}



