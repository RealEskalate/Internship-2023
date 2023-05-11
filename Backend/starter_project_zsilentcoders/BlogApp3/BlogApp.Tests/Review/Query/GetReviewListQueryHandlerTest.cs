using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Reviews.CQRS.Handlers.Queries;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Profiles;
using BlogApp.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.Tests.Reviews.Query
{
    public class GetReviewListQueryHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private GetReviewListQueryHandler _handler { get; set; }

        public GetReviewListQueryHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new GetReviewListQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetReviewListValid()
        {
            var result = await _handler.Handle(new GetReviewListQuery() { ReviewerId = 1 }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task GetReviewListInvalid()
        {
            var result = await _handler.Handle(new GetReviewListQuery() { ReviewerId = 100 }, CancellationToken.None);
            result.Success.ShouldBeFalse();
        }
    }
}
