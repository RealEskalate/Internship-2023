using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace CineFlex.Application.UnitTest.Seat.Commands;

public class CreateSeatCommandHandlerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public CreateSeatCommandHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldCreateSeatAndReturnSuccessResponse()
    {
        // Arrange
        var command = new CreateSeatCommand
        {
            CreateSeatDto = new CreateSeatDto
            {
                CinemaId = 1,
                Name = "A00"
            }
        };

        var handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        _mockMapper.Setup(m => m.Map<Domain.Seat>(command.CreateSeatDto)).Returns(new Domain.Seat());

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Add(It.IsAny<Domain.Seat>()))
            .ReturnsAsync(new Domain.Seat { Id = 1 });
        _mockUnitOfWork.Setup(uow => uow.Save()).ReturnsAsync(1);

        _mockUnitOfWork.Setup(uow => uow.CinemaRepository.Exists(It.IsAny<int>())).Returns(Task.FromResult(true));

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<int>>();
        response.Success.Should().BeTrue();
        response.Message.Should().Be("Creation Successful");
        response.Value.Should().Be(1);

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Add(It.IsAny<Domain.Seat>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldReturnFailureResponseWithErrors()
    {
        // Arrange
        var command = new CreateSeatCommand { CreateSeatDto = new CreateSeatDto() };

        var handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        var validationResult = new ValidationResult();
        validationResult.Errors.Add(new ValidationFailure("PropertyName", "Error message"));

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Add(It.IsAny<Domain.Seat>()))
            .ReturnsAsync(new Domain.Seat { Id = 1 });
        _mockUnitOfWork.Setup(uow => uow.Save()).ReturnsAsync(1);

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<int>>();
        response.Success.Should().BeFalse();
        response.Message.Should().Be("Seat Creation Failed");

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Add(It.IsAny<Domain.Seat>()), Times.Never);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
    }
}