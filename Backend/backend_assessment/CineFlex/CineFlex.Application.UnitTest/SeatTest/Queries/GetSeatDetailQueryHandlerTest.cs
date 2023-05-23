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
    public class GetCheckListDetailQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetCheckListDetailQueryHandler _handler;


        public GetCheckListDetailQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
          {
              c.AddProfile<MappingProfile>();
          });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCheckListDetailQueryHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task GetCheckListDetailQueryHandler_Success()
        {
            var result = await _handler.Handle(new GetCheckListDetailQuery { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType<Result<CheckListDto>>();
            result.Success.ShouldBeTrue();
        }

        [Fact]

        public async Task GetCheckListDetailQueryHandler_Fail()
        {
            var result = await _handler.Handle(new GetCheckListDetailQuery { Id = 3 }, CancellationToken.None);
            result.ShouldBeOfType<Result<CheckListDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeNull();
        }
    }
}