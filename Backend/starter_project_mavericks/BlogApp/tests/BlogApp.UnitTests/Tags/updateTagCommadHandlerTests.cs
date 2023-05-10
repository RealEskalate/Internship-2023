using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Tags.CQRS.Commands;
using BlogApp.Application.Features._Tags.CQRS.Handlers;
using BlogApp.Application.Features._Tags.DTOs;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.UnitTests.Tags
{
    public class updateTagCommadHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly updateTagCommandHandler _handler;

        public updateTagCommadHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new updateTagCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task Valid_TagUpdateTest()
        {
            var TagUpdate = new updateTagDto
            {
                Id = 2,
                Title = "New Fifth Tag Title",
                Description = "This is the updated content of the fifth tag description"
                
            };
            var response = await _handler.Handle(new updateTagCommand()
            {
                _TagDto = TagUpdate
            }, CancellationToken.None);

            var blog = await _mockUow.Object._TagRepository.Get(id: 2);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeTrue();
            blog.Title.ShouldBe(TagUpdate.Title);
            blog.Description.ShouldBe(TagUpdate.Description);
           
        }

        [Fact]
        public async Task Invalid_TagUpdateWithInvalidIdTest()
        {
            var response = await _handler.Handle(new updateTagCommand()
            {
                _TagDto = new updateTagDto
                {
                    Id = 2000,
                    Description = "This is the updated content of the fifth blog"
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

       

        [Fact]
        public async Task Invalid_TagUpdateWithEmptyTitleTest()
        {
            var response = await _handler.Handle(new updateTagCommand()
            {
                _TagDto = new updateTagDto
                {
                    Id = 2,
                    Title = ""
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Invalid_TagUpdateWithEmptyDescriptionTest()
        {
            var response = await _handler.Handle(new updateTagCommand()
            {
                _TagDto = new updateTagDto
                {
                    Id = 2,
                    Description = ""
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }
    }
}
