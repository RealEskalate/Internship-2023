﻿using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
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
    public class CreateSeatHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private CreateSeatCommandHandler _handler { get; set; }

        public CreateSeatHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task CreateSeatValid()
        {

            var seatDto = new CreateSeatDto()
            {
                Id = 5,
                Movie = "new movie",
                cinemaEntity = "new cinima",
                RowNumber = 1,
                SeatType = SeatType.VIP,
                SeatStatus = SeatStatus.Occupied,
                SeatPrice = 100,
                SeatDescription = "description",
                DateTime = DateTime.Now.AddDays(7),

            };


            var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = seatDto }, CancellationToken.None);

            // should get the current review
            var seat = await _mockUnitOfWork.Object.SeatRepository.Get(5);
            seat.ShouldNotBeNull();

            // the count should be 3 because there are 2 that are already added
            var reviews = await _mockUnitOfWork.Object.SeatRepository.GetAll();
            reviews.Count.ShouldBe(3);
        }

        [Fact]
        public async Task CreateSeatInvalid()
        {
            // mising required values
            var seatDto = new CreateSeatDto()
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
                var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = seatDto }, CancellationToken.None);

            } catch (Exception ex)
            {
                var seat = await _mockUnitOfWork.Object.SeatRepository.Get(10);
                seat.ShouldBeNull();

                // the count should be 3 because there are 2 that are already added
                var reviews = await _mockUnitOfWork.Object.SeatRepository.GetAll();
                reviews.Count.ShouldBe(2);
            }
            
        }
    }
}
