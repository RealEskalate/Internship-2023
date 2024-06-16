using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Profiles;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands;

    public class DeleteSeatCommandHandlerTests
    {
        private IMapper _mapper;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private DeleteSeatCommandHandler _handler;

        public DeleteSeatCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new DeleteSeatCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task DeleteSeatValid()
        {
            // Arrange
            var seat = new Seat
            {
                Id = 1,
                SeatNumber = 1
            };

            _mockUnitOfWork.Setup(x => x.SeatRepository.Get(seat.Id)).ReturnsAsync(seat);

            // Act
            await _handler.Handle(new DeleteSeatCommand() { Id = seat.Id }, CancellationToken.None);

            // Assert
            _mockUnitOfWork.Verify(x => x.SeatRepository.Delete(seat), Times.Once);
            _mockUnitOfWork.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteSeatInvalid()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.SeatRepository.Get(999)).ReturnsAsync((Seat)null);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(new DeleteSeatCommand() { Id = 999 }, CancellationToken.None));
        }
    }

