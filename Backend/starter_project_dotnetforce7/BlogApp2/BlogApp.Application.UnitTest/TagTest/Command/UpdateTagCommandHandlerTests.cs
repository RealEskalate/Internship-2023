using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.DTOs;
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
using Xunit;

namespace BlogApp.Application.UnitTest.TagTest.Command
{
    public class UpdateTagCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly TagDto _tagDto;
        private readonly UpdateTagCommandHandler _handler;
        public UpdateTagCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _tagDto = new TagDto
            {
                Id = 3,
                Title = "updated",
                Description = "this is an updated tag",
            };

            _handler = new UpdateTagCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateTag()
        {
            var result = await _handler.Handle(new UpdateTagCommand { TagDto = _tagDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var tag = await _mockRepo.Object.TagRepository.Get(_tagDto.Id);
            tag.Id.Equals(_tagDto.Id);
            tag.Title.Equals(_tagDto.Title);
            tag.Description.Equals(_tagDto.Description);

        }

        [Fact]
        public async Task Update_With_Invalid_TagNO()
        {

            _tagDto.Title = "this title has a characteer count more than 10";

            var result = await _handler.Handle(new UpdateTagCommand { TagDto = _tagDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var tags = await _mockRepo.Object.TagRepository.GetAll();
            tags.Count.ShouldBe(3);

        }


    }
}
