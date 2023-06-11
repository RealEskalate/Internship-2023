using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Posts
{
    public class DeleteCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeletePostCommandHandler _handler;

        public DeleteCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            _handler = new DeletePostCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async void ValidatePostDeletionTest()
        {
            

            var request = new DeletePostCommand { Id = 1 };
            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<Unit>>();
            response.Success.ShouldBeTrue();



        }

        [Fact]
        public async void InValidatePostDeletionTest()
        {
            

            var request = new DeletePostCommand { Id = 5000 };
            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<Unit>>();
            response.Success.ShouldBeFalse();



        }
    }
}
