using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using BlogApp.Application.Features.Reviews.CQRS.Handlers.Queries;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
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
    public class GetReviewDetainQueryHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private GetReviewDetailQueryHandler _handler { get; set; }

        public GetReviewDetainQueryHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new GetReviewDetailQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetReviewDetailValid()
        {
            var result = await _handler.Handle(new GetReviewDetailQuery() { Id = 1 }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task GetReviewDetailInvalid()
        {
            //NotFoundException ex = await Should.ThrowAsync<NotFoundException>(async () =>
            //{
            var result = await _handler.Handle(new GetReviewDetailQuery() { Id = 10 }, CancellationToken.None);
            result.Success.ShouldBeFalse();
            //});
        }
    }
}
