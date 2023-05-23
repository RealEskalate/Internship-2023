using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands
{
    public class DeleteSeatCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IUserAccessor> _mockUserAccessor;
        private readonly int _seatId;
        private readonly DeleteCommandHandler _handler;

        public DeleteSeatCommandHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUserAccessor = new Mock<IUserAccessor>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<Profiles.MappingProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();

            _seatId = 1;

            _handler = new DeleteCommandHandler(_mockUnitOfWork.Object, mapper, _mockUserAccessor.Object);
        }

        [Fact]
        public async Task Handle_ExistingSeatId_ReturnsSuccessResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var existingSeat = new SeatEntity { Id = _seatId };
            _mockUnitOfWork.Setup(u => u.SeatRepository.Get(_seatId)).ReturnsAsync(existingSeat);
            _mockUnitOfWork.Setup(u => u.Save()).ReturnsAsync(1);
            _mockUserAccessor.Setup(u => u.GetCurrentUser()).ReturnsAsync(new AppUser());

            // Act
            var response = await _handler.Handle(new DeleteSeatCommand { Id = _seatId }, cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("Delete Successful");
            response.Value.ShouldBe(Unit.Value);

      
        }

        [Fact]
        public async Task Handle_NonExistingSeatId_ReturnsErrorResponse()
        {
            // Arrange
            int nonExistingSeatId = 0;
            var cancellationToken = CancellationToken.None;
            _mockUnitOfWork.Setup(u => u.SeatRepository.Get(nonExistingSeatId)).ReturnsAsync((SeatEntity)null);
            _mockUserAccessor.Setup(u => u.GetCurrentUser()).ReturnsAsync(new AppUser());

            // Act
            var response = await _handler.Handle(new DeleteSeatCommand { Id = nonExistingSeatId }, cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeFalse();
            response.Message.ShouldBe("Delete Failed");

         
        }
    }
}
