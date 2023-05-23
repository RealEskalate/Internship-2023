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
    public class GetSeatDetailQueryTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private GetSeatDetailQueryHandler _handler { get; set; }

        public GetSeatDetailQueryTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new GetSeatDetailQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetReviewDetailValid()
        {
            var result = await _handler.Handle(new GetSeatDetailQuery() { Id = 1 }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task GetReviewDetailInvalid()
        {
            //NotFoundException ex = await Should.ThrowAsync<NotFoundException>(async () =>
            //{
            var result = await _handler.Handle(new GetSeatDetailQuery() { Id = 10 }, CancellationToken.None);
            result.Success.ShouldBeFalse();
            //});
        }
    }
}