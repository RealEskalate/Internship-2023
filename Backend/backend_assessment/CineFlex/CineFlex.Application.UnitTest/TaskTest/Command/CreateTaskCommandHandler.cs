using CineFlex.Application.Responses;

using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Profiles;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.CQRS.Handlers;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Domain;

namespace UnitTest.STest.Command
{
    public class CreateSeatCommandHandlerTest
    {

        private readonly IMapper _mapper;

        private readonly Mock<IUnitOfWork> _mockRepo;

        private readonly CreateTaskDto _taskDto;

        private readonly CreateTaskCommandHandler _handler;

        public CreateSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new CreateTaskDto
            {
                Id = 1,
                Title = "First title",
                Description = "First description",
                StartDate = new DateTime(2023, 6, 12, 9, 0, 0),
                EndDate = new DateTime(2023, 6, 15, 17, 30, 0),
                isComplete = true,
            };

            _handler = new CreateTaskCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task CreateTaskCommandHandlerSuccess()
        {
            var result = await _handler.Handle(new CreateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);

            result.ShouldBeOfType(BaseCommandResponse<int>);

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(3);

        }

        [Fact]
        public async Task CreateSeatCommandHandlerFail()
        {
            _taskDto.Title = null;
            var result = await _handler.Handle(new CreateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);

            result.ShouldBeOfType(BaseCommandResponse<int>);
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(2);
        }

    }
}