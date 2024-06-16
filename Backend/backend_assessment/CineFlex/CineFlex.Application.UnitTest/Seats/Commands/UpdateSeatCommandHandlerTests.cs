using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;


namespace CineFlex.Application.UnitTest.Seats.Commands;

    public class UpdateSeatCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly UpdateSeatCommandHandler _handler;

        public UpdateSeatCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateSeatDto, Seat>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new UpdateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task UpdateSeatCommandHandler_WhenSeatExists_ShouldUpdateSeat()
        {
            // Arrange
            var existingSeatId = 1;
            var existingSeat = new Seat
            {
                Id = existingSeatId,
                SeatNumber = 2
            };
            var updateDto = new UpdateSeatDto
            {
                Id = existingSeatId,
                SeatNumber = 3
            };
             var command = new UpdateSeatCommand()
                        {
                        UpdateSeatDto = updateDto
                        };
            _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(existingSeatId))
                .ReturnsAsync(existingSeat);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.SeatRepository.Update(It.IsAny<Seat>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
            existingSeat.SeatNumber.Should().Be(updateDto.SeatNumber);
        }

        [Fact]
        public async Task UpdateSeatCommandHandler_WhenSeatDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var nonExistingSeatId = 1;
            var updateDto = new UpdateSeatDto
            {
                Id = nonExistingSeatId,
                SeatNumber = 2
            };
          var command = new UpdateSeatCommand()
                        {
                            UpdateSeatDto = updateDto
                        };
            _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(nonExistingSeatId))
                .ReturnsAsync(() => null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }


