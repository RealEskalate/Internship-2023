using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Profiles;
using BlogApp.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using Xunit;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using Shouldly;

namespace BlogApp.Application.UnitTest.TagTest.Command
{
    public class DeleteTagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly DeleteTagCommandHandler _handler;
        private readonly CreateTagDto _tagDto;

        public DeleteTagCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _tagDto = new CreateTagDto
            {
                Title = "delete",
                Description = "tag created from the delete test",
            };


            _handler = new DeleteTagCommandHandler(_mockRepo.Object, _mapper);

        }

        [Fact]
        public async Task DeleteTag()
        {

            var result = await _handler.Handle(new DeleteTagCommand { Id = 2 }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var tags = await _mockRepo.Object.TagRepository.GetAll();
            tags.Count().ShouldBe(2);

        }

        [Fact]
        public async Task Delete_Tag_Doesnt_Exist()
        {
            var result = await _handler.Handle(new DeleteTagCommand { Id = 0 }, CancellationToken.None);
            result.ShouldBe(null);

            var tags = await _mockRepo.Object.TagRepository.GetAll();
            tags.Count().ShouldBe(3);


        }

    }
}
