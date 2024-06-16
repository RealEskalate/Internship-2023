using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Commands;
using Application.Features.CheckList.CQRS.Handlers;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.CheckListTest.Command
{
    public class DeleteCheckListCommandHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly DeleteCheckListCommandHandler _handler;


        public DeleteCheckListCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
          {
              c.AddProfile<MappingProfile>();
          });
            _mapper = mapperConfig.CreateMapper();

            _handler = new DeleteCheckListCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task DeleteCheckListCommandHandler_Success()
        {
            var result = await _handler.Handle(new DeleteCheckListCommand { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();

            var checkLists = await _mockRepo.Object.CheckListRepository.GetAll();
            checkLists.Count.ShouldBe(1);

        }
        [Fact]

        public async Task DeleteCheckListCommandHandler_Fail()
        {
            var result = await _handler.Handle(new DeleteCheckListCommand { Id = 3 }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();

            var checkLists = await _mockRepo.Object.CheckListRepository.GetAll();
            checkLists.Count.ShouldBe(2);

        }

    }
}
