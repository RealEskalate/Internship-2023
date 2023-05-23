using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Tests.Seats.CQRS.Commands
{
    public class CreateSeatCommandHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly CreateSeatCommandHandler _handler;

        public CreateSeatCommandHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new CreateSeatCommandHandler(_mockSeatRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidSeatDto_ShouldReturnSuccessfulResponse()
        {
            // Arrange
            var seatDto = new CreateSeatDto { Row = 1, Number = 2, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };
            _mockSeatRepository.Setup(r => r.AddAsync(It.IsAny<SeatDto>())).ReturnsAsync(1);

            var command = new CreateSeatCommand { SeatDto = seatDto };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Value.ShouldBe(1);
        }

        [Fact]
        public async Task Handle_InvalidSeatDto_ShouldReturnUnsuccessfulResponse()
        {
            // Arrange
            var seatDto = new CreateSeatDto { Row = 0, Number = 2, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };

            var command = new CreateSeatCommand { SeatDto = seatDto };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeFalse();
            response.Value.ShouldBe(default);
        }
    }
}
