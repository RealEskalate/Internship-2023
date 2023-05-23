using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain;
using Moq;
using System.Threading;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Queries;

    public class GetSeatDetailQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public GetSeatDetailQueryHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Handle_WithValidQuery_ShouldReturnSeatDto()
        {
            // Arrange
            var seatId = 1;
            var seat = new Seat { Id = seatId,SeatNumber = 1 };
            var expectedSeatDto = new SeatDto { Id = seatId,SeatNumber = 2 };
            var query = new GetSeatDetailQuery { Id = seatId };
            var cancellationToken = new CancellationToken();

            _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(seatId)).ReturnsAsync(seat);
            _mockMapper.Setup(m => m.Map<SeatDto>(seat)).Returns(expectedSeatDto);

            var handler = new GetSeatDetailQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.Equal(expectedSeatDto, result);
        }
    }

