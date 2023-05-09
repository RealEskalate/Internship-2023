using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.CQRS.Handlers;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Ratetest.Command
{
    public class CreateCommentCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateCommentDto _commentDto;
        private readonly CreateCommentCommandHandler _handler;
        public CreateCommentCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _commentDto = new CreateCommentDto
            {
               Content = "Sample Content",
                    UserId = 3,
                    BlogId = 3,
            };

            _handler = new CreateCommentCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateComment()
        {
            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = _commentDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(3);

        }

        [Fact]
        public async Task InvalidComment_Added()
        {

            _commentDto.Content = "";
            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = _commentDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(2);

        }
    }
}




