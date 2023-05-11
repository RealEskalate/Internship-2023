using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Commenttest.Query
{
    public class GetCommentListQueryHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetCommentListQueryHandler _handler;
        public GetCommentListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCommentListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetRateList()
        {
            var result = await _handler.Handle(new GetCommentListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<CommentDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<List<CommentDto>>();
            result.Value.Count.ShouldBe(2);
        }
    }
}



