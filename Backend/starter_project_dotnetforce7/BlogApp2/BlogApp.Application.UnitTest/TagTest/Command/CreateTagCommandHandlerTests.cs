using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.UnitTest.Mocks;
using Moq;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlogApp.Application.Responses;
using Shouldly;

namespace BlogApp.Application.UnitTest.TagTest.Command
{
    public class CreateTagCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateTagCommandHandler _handler;
        private readonly CreateTagDto _tagDto;


        public CreateTagCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _tagDto = new CreateTagDto
            {
                Title = "New tag",
                Description = "this is a newly created tag"
            };

            _handler = new CreateTagCommandHandler(_mockRepo.Object, _mapper);

        }



        [Fact]
        public async Task CreateTag()
        {
            var result = await _handler.Handle(new CreateTagCommand { TagDto = _tagDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();
            var tags = await _mockRepo.Object.TagRepository.GetAll();
            tags.Count.ShouldBe(4);

        }

        [Fact]
        public async Task InvalidTag_Added()
        {
            _tagDto.Title = "this title has a characteer count more than 10";
            var result = await _handler.Handle(new CreateTagCommand { TagDto = _tagDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();

            var tags = await _mockRepo.Object.TagRepository.GetAll();
            tags.Count.ShouldBe(3);

        }





    }
}
