using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.CQRS.Handlers;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Rates.Command
{
    public class CreateRateCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateRateDto _rateDto;
        private readonly CreateRateCommandHandler _handler;
        public CreateRateCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _rateDto = new CreateRateDto
            {
                RateNo=5,
                RaterId=3,
                BlogId = 4
            };

            _handler = new CreateRateCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateRate()
        {
            var result = await _handler.Handle(new CreateRateCommand() { RateDto = _rateDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(3);

        }

        [Fact]
        public async Task InvalidRate_Added()
        {

            _rateDto.RateNo = -1;
            var result = await _handler.Handle(new CreateRateCommand() { RateDto = _rateDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(2);

        }
    }
}




