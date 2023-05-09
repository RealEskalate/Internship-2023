using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.CQRS.Handlers;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
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

namespace BlogApp.Application.UnitTest.Ratetest.Query
{
    public class GetCommentDetailQueryHandlerTest
    {


      

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int Id;
        private readonly GetCommentDetailQueryHandler _handler;
        public GetCommentDetailQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            Id = 1;

            _handler = new GetCommentDetailQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetCommentDetail()
        {
            var result = await _handler.Handle(new GetCommentDetailQuery() { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<Result<CommentDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<CommentDto>();
        }

        [Fact]
        public async Task GetNonExistingComment()
        {

            Id = 0;
            var result = await _handler.Handle(new GetCommentDetailQuery() { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<Result<CommentDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(null);
        }
    }
}

