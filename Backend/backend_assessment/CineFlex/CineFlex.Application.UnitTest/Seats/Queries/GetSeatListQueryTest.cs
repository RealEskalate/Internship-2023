using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Queries;
using CineFlex.Application.Features.Seats.CQRS.Queries;
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

namespace CineFlex.Application.UnitTest.Seats.Queries
{
    public class GetSeatListQueryTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private GetSeatListQueryHandler _handler { get; set; }

        public GetSeatListQueryTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new GetSeatListQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetSeatListValid()
        {
            var result = await _handler.Handle(new GetSeatListQuery() { }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }
    }
}