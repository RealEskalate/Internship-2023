using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

using Xunit;

namespace CineFlex.Application.UnitTest.PostTest.Query
{
    public class GetPostDetailQueryHandlerTest
	{


		private readonly IMapper _mapper;
		private readonly Mock<IUnitOfWork> _mockRepo;
		private int Id;
		private readonly GetPostDetailQueryHandler _handler;
		public GetPostDetailQueryHandlerTest()
		{
			_mockRepo = MockUnitOfWork.GetUnitOfWork();
			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<MappingProfile>();
			});
			_mapper = mapperConfig.CreateMapper();

			Id = 1;

			_handler = new GetPostDetailQueryHandler(_mockRepo.Object, _mapper);

		}


		[Fact]
		public async Task GetPostDetail()
		{
			var result = await _handler.Handle(new GetPostDetailQuery() { Id = Id }, CancellationToken.None);
			result.ShouldBeOfType<BaseCommandResponse<PostDto>>();
			result.Success.ShouldBeTrue();
			result.Value.ShouldBeOfType<PostDto>();
		}

		[Fact]
		public async Task GetNonExistingPost()
		{

			Id = 0;
			var result = await _handler.Handle(new GetPostDetailQuery() { Id = Id }, CancellationToken.None);
			result.ShouldBeOfType<BaseCommandResponse<PostDto>>();
			result.Success.ShouldBeTrue();
			result.Value.ShouldBe(null);
		}
	}
}

