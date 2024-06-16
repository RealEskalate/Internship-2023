
using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Handlers;
using Moq;
using AutoMapper;
using UnitTest.Mocks;
using Application.Profiles;
using Application.Features.CheckList.CQRS.Queries;
using Shouldly;
using Application.Responses;
using Application.Features.CheckList.DTOs;

namespace UnitTest.CheckListTest.Queries
{
    public class GetCheckListListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetCheckListListQueryHandler _handler;

        public GetCheckListListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
          {
              c.AddProfile<MappingProfile>();
          });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCheckListListQueryHandler(_mockRepo.Object, _mapper);
        }


        [Fact]


        public async Task GetCheckListListQueryHandler_Success()
        {
            var result = await _handler.Handle(new GetCheckListListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<CheckListDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.Count.ShouldBe(2);
        }


    }
}