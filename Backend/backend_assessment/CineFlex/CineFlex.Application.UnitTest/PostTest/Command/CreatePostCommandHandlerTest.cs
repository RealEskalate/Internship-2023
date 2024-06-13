using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.PostTest.Command
{
    public class CreatePostCommandHandlerTest
	{

		private readonly IMapper _mapper;
		private readonly Mock<IUnitOfWork> _mockRepo;
		private readonly CreatePostDto _postDto;
		private readonly CreatePostCommandHandler _handler;
		public CreatePostCommandHandlerTest()
		{
			_mockRepo = MockUnitOfWork.GetUnitOfWork();
			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<MappingProfile>();
			});
			_mapper = mapperConfig.CreateMapper();

			_postDto = new CreatePostDto
			{
				Title = "Title for post one",
				Content = "Content for post one",
				UserId = 2,
			};

			_handler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);

		}


		[Fact]
		public async Task CreatePost()
		{
			var result = await _handler.Handle(new CreatePostCommand() { PostDto = _postDto }, CancellationToken.None);
			result.ShouldBeOfType<BaseCommandResponse<int>>();
			result.Success.ShouldBeTrue();

			var posts = await _mockRepo.Object.PostRepository.GetAll();
			posts.Count.ShouldBe(3);

		}

		[Fact]
		public async Task InvalidPost_Added()
		{

			_postDto.UserId = -1;
			var result = await _handler.Handle(new CreatePostCommand() { PostDto = _postDto }, CancellationToken.None);
			result.ShouldBeOfType<BaseCommandResponse<int>>();
			// result.Success.ShouldBeFalse();
			result.Errors.ShouldBeNull();
			var posts = await _mockRepo.Object.PostRepository.GetAll();
			posts.Count.ShouldBe(3);

		}
	}
}




