using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xunit;

namespace CineFlex.Application.UnitTest.Seat.Commands;

public class UpdateSeatCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;

    public UpdateSeatCommandHandlerTest()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldUpdateSeatAndReturnSuccessResponse()
    {
        // Arrange
        var command = new UpdateSeatCommand { UpdateSeatDto = new UpdateSeatDto { Id = 1, Name = "GGD" } };

        var handler = new UpdateSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        var validationResult = new FluentValidation.Results.ValidationResult();

        var existingSeat = new Domain.Seat { Id = 1 };

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(command.UpdateSeatDto.Id)).ReturnsAsync(existingSeat);
        _mockMapper.Setup(m => m.Map(command.UpdateSeatDto, existingSeat)).Returns(existingSeat);
        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Update(existingSeat));
        _mockUnitOfWork.Setup(uow => uow.Save()).ReturnsAsync(1);
        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Exists(It.IsAny<int>())).Returns(Task.FromResult(true));

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<Unit>>();
        response.Success.Should().BeTrue();
        response.Message.Should().Be("Seat updated successfully.");

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Get(command.UpdateSeatDto.Id), Times.Once);
        _mockMapper.Verify(m => m.Map(command.UpdateSeatDto, existingSeat), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Update(existingSeat), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldReturnFailureResponseWithErrors()
    {
        // Arrange
        var command = new UpdateSeatCommand { UpdateSeatDto = new UpdateSeatDto { Id = 1 } };

        var handler = new UpdateSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        var validationResult = new FluentValidation.Results.ValidationResult();
        validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("PropertyName", "Error message"));

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(command.UpdateSeatDto.Id)).ReturnsAsync((Domain.Seat)null);

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<Unit>>();
        response.Success.Should().BeFalse();
        response.Message.Should().Be("Seat Update Failed");

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Exists(command.UpdateSeatDto.Id), Times.Once);
        _mockMapper.Verify(m => m.Map(It.IsAny<UpdateSeatDto>(), It.IsAny<Domain.Seat>()), Times.Never);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Update(It.IsAny<Domain.Seat>()), Times.Never);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
    }
}