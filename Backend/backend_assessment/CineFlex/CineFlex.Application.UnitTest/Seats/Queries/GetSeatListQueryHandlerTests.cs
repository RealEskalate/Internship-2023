using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain;
using Moq;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Queries;

    public class GetSeatListQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public GetSeatListQueryHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_ReturnsListOfSeatDtos_WhenSeatExist()
        {
            // Arrange
            var seats = new List<Seat>
            {
                new Seat { Id = 1, SeatNumber = 2},
                new Seat { Id = 2, SeatNumber= 3 },
                new Seat { Id = 3,SeatNumber = 4}
            };

            var seatDtos = new List<SeatDto>
            {
                new SeatDto { Id = 1, SeatNumber = 2},
                new SeatDto { Id = 2, SeatNumber= 3 },
                new SeatDto { Id = 3,SeatNumber = 4}
            };

            _mockUnitOfWork.Setup(u => u.SeatRepository.GetAll()).ReturnsAsync(seats);
            _mockMapper.Setup(m => m.Map<List<SeatDto>>(seats)).Returns(seatDtos);

            var handler = new GetSeatListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetSeatListQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SeatDto>>(result);
            Assert.Equal(seatDtos.Count, result.Count);

            for (int i = 0; i < seatDtos.Count; i++)
            {
                Assert.Equal(seatDtos[i].Id, result[i].Id);
                Assert.Equal(seatDtos[i].SeatNumber, result[i].SeatNumber);
            }
        }

        [Fact]
        public async Task Handle_ReturnsEmptyList_WhenNoSeatExist()
        {
            // Arrange
            var seats = new List<Seat>();
            var seatDtos = new List<SeatDto>();

            _mockUnitOfWork.Setup(u => u.SeatRepository.GetAll()).ReturnsAsync(seats);
            _mockMapper.Setup(m => m.Map<List<SeatDto>>(seats)).Returns(seatDtos);

            var handler = new GetSeatListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetSeatListQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SeatDto>>(result);
            Assert.Empty(result);
        }
    }

