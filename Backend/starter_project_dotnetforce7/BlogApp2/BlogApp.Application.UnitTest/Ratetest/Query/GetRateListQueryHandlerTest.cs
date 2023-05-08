using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.CQRS.Handlers;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
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

namespace BlogApp.Application.UnitTest.Ratetest.Query
{
    public class GetRateListQueryHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetRateListQueryHandler _handler;
        public GetRateListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetRateListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetRateList()
        {
            var result = await _handler.Handle(new GetRateListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<RateDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<List<RateDto>>();
            result.Value.Count.ShouldBe(2);
        }
    }
}



