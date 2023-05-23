using AutoMapper;
using FluentValidation;
using Moq;
using Shouldly;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Domain;
using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.UnitTest.Seats.Commands
{
    public class CreateSeatCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IUserAccessor> _mockUserAccessor;
        private readonly IMapper _mapper;
        private readonly CreateSeatDto _seatDto;
        private readonly CreateSeatCommandHandler _handler;

        public CreateSeatCommandHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUserAccessor = new Mock<IUserAccessor>();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<Profiles.MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            _seatDto = new CreateSeatDto
            {
                // Set seat DTO properties
                CinemaId = 1,
                SeatNumber = 1
            };

            _handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mapper, _mockUserAccessor.Object);
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsSuccessResponse()
        {
            // Arrange
            _mockUserAccessor.Setup(u => u.GetCurrentUser()).ReturnsAsync(new AppUser());
            _mockUnitOfWork.Setup(u => u.SeatRepository.Add(It.IsAny<SeatEntity>())).ReturnsAsync(new SeatEntity());
            _mockUnitOfWork.Setup(u => u.Save()).ReturnsAsync(1);

            var command = new CreateSeatCommand { SeatDto = _seatDto };
            var cancellationToken = CancellationToken.None;

            // Act
            var response = await _handler.Handle(command, cancellationToken);

            // Assert

            Console.WriteLine("Value");
            Console.WriteLine(response.Value);
            Console.WriteLine(response.Message);


            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("Creation Successfull");

            _mockUserAccessor.Verify(u => u.GetCurrentUser(), Times.Once);
            _mockUnitOfWork.Verify(u => u.SeatRepository.Add(It.IsAny<SeatEntity>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.Save(), Times.Once);
        }



    }
}
