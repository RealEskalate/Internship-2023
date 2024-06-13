using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands
{
    public class UpdateSeatHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private UpdateSeatCommandHandler _handler { get; set; }

        public UpdateSeatHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new UpdateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task UpdateseatValid()
        {

            var seatDto = new UpdateSeatDto()
            {
                Id = 1,
                Movie = "upda movie",
                cinemaEntity = "new cinima",
                RowNumber = 1,
                SeatType = SeatType.VIP,
                SeatStatus = SeatStatus.Occupied,
                SeatPrice = 100,
                SeatDescription = "updated",
                DateTime = DateTime.Now.AddDays(7),

            };


            var result = await _handler.Handle(new UpdateSeatCommand() { seatDto = seatDto }, CancellationToken.None);

            // should get the current review
            var seat = await _mockUnitOfWork.Object.SeatRepository.Get(1);
            seat.ShouldNotBeNull();
            seat.SeatDescription.ShouldBe(seatDto.SeatDescription);

        }

        [Fact]
        public async Task CreateSeatInvalid()
        {
            // mising required values
            var seatDto = new UpdateSeatDto()
            {
                Id = 10,
                SeatType = SeatType.VIP,
                SeatStatus = SeatStatus.Occupied,
                SeatPrice = 100,
                SeatDescription = "description",
                DateTime = DateTime.Now.AddDays(7),

            };

            try
            {
                var result = await _handler.Handle(new UpdateSeatCommand() { seatDto = seatDto }, CancellationToken.None);

            }
            catch (Exception ex)
            {
                var seat = await _mockUnitOfWork.Object.SeatRepository.Get(10);
                seat.ShouldBeNull();
            }

        }
    }
}
