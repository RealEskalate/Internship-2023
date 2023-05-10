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
    public class Create_TagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Create_TagCommandHandler _handler;

        public Create_TagCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new Create_TagCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task Valid_TagCreationTest()
        {
            var response = await _handler.Handle(new Create_TagCommand()
            {
                _TagDto = new Create_TagDto
                {
                    Title = "Fifth Tag Title",
                    Description = "This is the content of the fifth tag description"
                    
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(5);
        }


        [Fact]
        public async Task Invalid_TagCreationWithEmptyTitleTest()
        {
            var response = await _handler.Handle(new Create_TagCommand()
            {
                _TagDto = new Create_TagDto
                {
                    Title = "",
                    Description = "This is the content of an invalid tag description"
                    
                },
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task Invalid_TagCreationWithEmptyDescriptionTest()
        {
            var response = await _handler.Handle(new Create_TagCommand()
            {
                _TagDto = new Create_TagDto
                {
                    Title = "This is an invalid tag title",
                    Description = ""
                    
                },
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
            response.Success.ShouldBeFalse();
        }

        

        
    }
}
