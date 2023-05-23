using System.Data;

using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Handlers;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Responses;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands


{
    public class UpdateSeatCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateSeatDto _seatsDto;
        private readonly UpdateSeatCommandHandler _handler;
        public UpdateSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _seatsDto = new UpdateSeatDto
            {
                SeatNumber = "123",
                SeatType = SeatType.VIP,
                Availability = Availability.Taken,
            };

            _handler = new UpdateSeatCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateBlog()
        {
            var result = await _handler.Handle(new UpdateSeatCommand() { updateSeatDto = _seatsDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();

            var seat = await _mockRepo.Object.SeatRepository.Get(_seatsDto.Id);
            seat.Availability.Equals(_seatsDto.Availability);
            seat.SeatNumber.Equals(_seatsDto.SeatNumber);
        }

        [Fact]
        public async Task Update_With_Invalid_PulicationStatus()
        {

           
            var result = await _handler.Handle(new UpdateSeatCommand() { updateSeatDto = _seatsDto }, CancellationToken.None);
            
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(2);

        }


    }
}


