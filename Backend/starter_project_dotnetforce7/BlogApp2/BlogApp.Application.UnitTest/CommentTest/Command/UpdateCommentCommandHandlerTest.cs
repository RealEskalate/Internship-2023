using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Ratetest.Command
{
    public class UpdateCommentCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateCommentDto _commentDto;
        private readonly UpdateCommentCommandHandler _handler;
        public UpdateCommentCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _commentDto = new UpdateCommentDto
            {
                Id = 1,
                Content = "Update content",
                
            };

            _handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateComment()
        {
            var result = await _handler.Handle(new UpdateCommentCommand() { CommentDto = _commentDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var comment = await _mockRepo.Object.CommentRepository.Get(_commentDto.Id);
            comment.Id.Equals(_commentDto.Id);
            
            comment.Content.Equals(_commentDto.Content);
            
        }

        [Fact]
        public async Task Update_With_Invalid_CommentContnet()
        {

            _commentDto.Content = "";
            var result = await _handler.Handle(new UpdateCommentCommand() { CommentDto = _commentDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var comments = await _mockRepo.Object.CommentRepository.GetAll();
            comments.Count.ShouldBe(2);

        }


    }
}



