using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;
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

namespace BlogApp.Application.UnitTest.Commenttest.Command
{
    public class DeleteCommentCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteCommentCommandHandler _handler;
        private readonly CreateCommentDto _commentDto;
        public DeleteCommentCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _commentDto = new CreateCommentDto
            {
                Content = "This is Content",
                 UserId= 3,
                BlogId = 4
            };
            _id = 1;

            _handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteComment()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteCommentCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var comments = await _mockRepo.Object.CommentRepository.GetAll();
            comments.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Comment_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeleteCommentCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);
        
            var comments = await _mockRepo.Object.RateRepository.GetAll();
            comments.Count.ShouldBe(2);

        }
    }
}



