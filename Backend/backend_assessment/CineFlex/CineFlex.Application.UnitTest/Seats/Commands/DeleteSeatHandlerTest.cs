using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.UnitTest.Mocks;
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
    public class DeleteSeatHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private DeleteSeatCommandHandler _handler { get; set; }


        public DeleteSeatHandlerTest()
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

            var Id = 1;

            var result = await _handler.Handle(new DeleteSeatCommand() { SeatId = Id }, CancellationToken.None);


            // the count should be 1
            var seats = await _mockUnitOfWork.Object.SeatRepository.GetAll();
            var exist = await _mockUnitOfWork.Object.SeatRepository.Exists(1);
            exist.ShouldBeFalse();
            seats.Count.ShouldBe(1);
        }

        [Fact]
        public async Task DeleteSeatInvalid()
        {

            var Id = 10;
            var result = await _handler.Handle(new DeleteSeatCommand() { SeatId = Id }, CancellationToken.None);
            var reviews = await _mockUnitOfWork.Object.SeatRepository.GetAll();
            reviews.Count.ShouldBe(2);

        }
    }
}
