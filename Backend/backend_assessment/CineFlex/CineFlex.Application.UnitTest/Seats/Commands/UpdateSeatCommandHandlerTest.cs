// using AutoMapper;
// using TaskManagement.Application.Contracts.Persistence;
// using TaskManagement.Application.Features.Tasks.CQRS.Commands;
// using TaskManagement.Application.Features.Tasks.CQRS.Handlers;
// using TaskManagement.Application.Features.Tasks.DTOs;
// using TaskManagement.Application.Profiles;
// using TaskManagement.Application.Responses;
// using TaskManagement.Application.UnitTest.Mocks;
// using MediatR;
// using Moq;
// using Shouldly;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace TaskManagement.Application.UnitTest.Tasks.Commands

// {
//     public class UpdateTaskCommandHandlerTest
//     {
//         private readonly IMapper _mapper;
//         private readonly Mock<IUnitOfWork> _mockRepo;
//         private readonly UpdateTaskDto _TaskDto;
//         private readonly UpdateTaskCommandHandler _handler;
//         public UpdateTaskCommandHandlerTest()
//         {
//             _mockRepo = MockUnitOfWork.GetUnitOfWork();
//             var mapperConfig = new MapperConfiguration(c =>
//             {
//                 c.AddProfile<MappingProfile>();
//             });
//             _mapper = mapperConfig.CreateMapper();

//             _TaskDto = new UpdateTaskDto
//             {
//                 Id = 1,
//                 Title = "title Updated",
//                 Description = "Updated Sample Content",
//                 Status = true,
//                 StartDate = DateTime.Now.Date,
//                 EndDate = DateTime.Now.Date,
//             };

//             _handler = new UpdateTaskCommandHandler(_mockRepo.Object, _mapper);

//         }


//         [Fact]
//         public async Task UpdateTask()
//         {
//             var result = await _handler.Handle(new UpdateTaskCommand() { TaskDto = _TaskDto }, CancellationToken.None);
//             result.ShouldBeOfType<Result<Unit>>();
//             result.Success.ShouldBeTrue();

//             var Task = await _mockRepo.Object.TaskRepository.Get(_TaskDto.Id);
//             Task.Title.Equals(_TaskDto.Title);
//             Task.Description.Equals(_TaskDto.Description);
//         }

//         [Fact]
//         public async Task UpdateTask_NonExistentTask_Fails()
//         {
//             // Arrange
//             _TaskDto.Id = 999; // Set a non-existent task ID

//             // Act
//             var result = await _handler.Handle(new UpdateTaskCommand() { TaskDto = _TaskDto }, CancellationToken.None);

//             // Assert
//             result.ShouldBe(null);
//             var task = await _mockRepo.Object.TaskRepository.Get(_TaskDto.Id);
//             task.ShouldBeNull(); // The task should not be found in the repository
//         }

//         [Fact]
//         public async Task UpdateTask_InvalidData_Fails()
//         {
//             // Arrange
//             _TaskDto.Title = ""; // Set an empty title to make the data invalid

//             // Act
//             var result = await _handler.Handle(new UpdateTaskCommand() { TaskDto = _TaskDto }, CancellationToken.None);

//             // Assert
//             result.ShouldBeOfType<Result<Unit>>();
//             result.Success.ShouldBeFalse();
//             result.Message.ShouldBe("Update Failed");
//             result.Errors.ShouldContain("Title is required.");

//             var task = await _mockRepo.Object.TaskRepository.Get(_TaskDto.Id);
//             task.ShouldNotBeNull(); // The task should still exist in the repository
//         }



       


//     }
// }



