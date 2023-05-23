using Moq;
using AutoMapper;
using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Handlers;
using Application.Features.CheckList.DTOs;
using UnitTest.Mocks;
using Application.Profiles;
using Application.Features.CheckList.CQRS.Commands;
using Shouldly;
using Application.Responses;
using MediatR;

namespace UnitTest.CheckListTest.Command
{
    public class UpdateCheckListCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateCheckListCommandHandler _handler;
        private readonly UpdateCheckListDto _checkListDto;


    public UpdateCheckListCommandHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        _checkListDto = new UpdateCheckListDto
        {
            Id = 1,
            Title = "title Update",
            Description = "description Update",
            Status = false
        };

        _handler = new UpdateCheckListCommandHandler(_mockRepo.Object, _mapper);
    }

    [Fact]

    public async Task UpdateCheckListCommandHandler_Success()
    {
        var result = await _handler.Handle(new UpdateCheckListCommand { CheckListDto = _checkListDto }, CancellationToken.None);
        result.ShouldBeOfType<Result<Unit>>();

        var checkList = await _mockRepo.Object.CheckListRepository.Get(_checkListDto.Id);
        checkList.Title.ShouldBe(_checkListDto.Title);
        checkList.Description.ShouldBe(_checkListDto.Description);
        checkList.Status.ShouldBe(_checkListDto.Status);
        checkList.Id.ShouldBe(_checkListDto.Id);

    }

    [Fact]

    public async Task UpdateCheckListCommandHandler_Fail()
    {
        _checkListDto.Title = null;

        var result = await _handler.Handle(new UpdateCheckListCommand { CheckListDto = _checkListDto }, CancellationToken.None);
        result.ShouldBeOfType<Result<Unit>>();
        result.Success.ShouldBeFalse();

        result.Errors.ShouldNotBeEmpty();

        var checkLists = await _mockRepo.Object.CheckListRepository.GetAll();
        checkLists.Count.ShouldBe(2);

    }
}}