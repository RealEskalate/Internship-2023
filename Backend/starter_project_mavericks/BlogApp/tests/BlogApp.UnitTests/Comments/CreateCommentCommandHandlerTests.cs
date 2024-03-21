using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.UnitTests.Comments
{
    public class CreateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCommentCommandHandler _handler;

        public CreateCommentCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCommentCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task ValidCommentCreationTest()
        {
            var response = await _handler.Handle(new CreateCommentCommand()
            {
                CommentDto = new CreateCommentDto
                {

                    Id = 1,
                    BlogId = "Hello",
                    Commenter = "Manchester United",
                    Content = "new",

                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
            response.Success.ShouldBeTrue();
           
        }



        [Fact]
        public async Task InvalidCommentCreationWithEmptyBlogId()
        {
            var response = await _handler.Handle(new CreateCommentCommand()
            {
                CommentDto = new CreateCommentDto
                {

                    Id = 1,
                    BlogId = "",
                    Commenter = "Manchester United",
                    Content = "new",

                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
            response.Success.ShouldBeFalse();
        }

    }
}