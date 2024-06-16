using CineFlex.Application.Responses;

using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Profiles;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.STest.Command
{
    public class CreateSeatCommandHandlerTest
    {

        private readonly IMapper _mapper;

        private readonly Mock<IUnitOfWork> _mockRepo;

        private readonly CreateSeatDto _seatDto;

        private readonly CreateSeatCommandHandler _handler;

        public CreateSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
          {
              c.AddProfile<MappingProfile>();
          });
            _mapper = mapperConfig.CreateMapper();

            _seatDto = new CreateSeatDto
              {
                 SeatNumber = 1,
                 IsBooked = true,
             };

            _handler = new CreateSeatCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task CreateSeatCommandHandler_Success()
        {
            var result = await _handler.Handle(new CreateSeatCommand { SeatDto = _seatDto }, CancellationToken.None);

            result.ShouldBeOfType(BaseCommandResponse<int>);

            var seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count.ShouldBe(3);

        }

        [Fact]
        public async Task CreateSeatCommandHandler_Fail()
        {
            _seatDto.IsBooked = null;
            var result = await _handler.Handle(new CreateSeatCommand { SeatDto = _seatDto }, CancellationToken.None);

            result.ShouldBeOfType( BaseCommandResponse<int>);
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();

            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count.ShouldBe(2);
        }

    }
}