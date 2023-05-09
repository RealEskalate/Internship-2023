using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.UnitTests.Comments
{
    public class UpdateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateCommentCommandHandler _handler;

        public UpdateCommentCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateCommentCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task ValidCommentUpdateTest()
        {
            var commentUpdate = new UpdateCommentDto
            {
              
                Commenter = "Manchester United",
                Content = "new",


            };
            var response = await _handler.Handle(new UpdateCommentCommand()
            {
                Id = 2,
                updateCommentDto = commentUpdate

            }, CancellationToken.None);

            var comment = await _mockUow.Object.CommentRepository.Get(id: 2);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
           
            

        }

        [Fact]
        public async Task InvalidCommentUpdateWithInvalidIdTest()
        {

            var commentUpdate = new UpdateCommentDto
            {
               
                Commenter = "Manchester United",
                Content = "new",


            };
            var response = await _handler.Handle(new UpdateCommentCommand()
            {
                Id = 100,
                updateCommentDto = commentUpdate
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidBlogUpdateWithEmptyContent()
        {
            var commentUpdate = new UpdateCommentDto
            {
                
                Commenter = "Manchester United",
                Content = "",


            };
            var response = await _handler.Handle(new UpdateCommentCommand()
            {
                Id = 3,
                updateCommentDto = commentUpdate
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }


    }
}