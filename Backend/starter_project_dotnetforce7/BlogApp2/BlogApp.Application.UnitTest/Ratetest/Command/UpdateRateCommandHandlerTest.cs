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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Ratetest.Command
{
    public class UpdateRateCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateRateDto _rateDto;
        private readonly UpdateRateCommandHandler _handler;
        public UpdateRateCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _rateDto = new UpdateRateDto
            {
                Id = 1,
                RateNo = 5,
                RaterId = 3,
                BlogId = 4
            };

            _handler = new UpdateRateCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateRate()
        {
            var result = await _handler.Handle(new UpdateRateCommand() { RateDto = _rateDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var rate = await _mockRepo.Object.RateRepository.Get(_rateDto.Id);
            rate.Id.Equals(_rateDto.Id);
            rate.BlogId.Equals(_rateDto.BlogId);
            rate.RateNo.Equals(_rateDto.RateNo);
            rate.RaterId.Equals(_rateDto.RaterId);
        }

        [Fact]
        public async Task Update_With_Invalid_RateNO()
        {

            _rateDto.RateNo = -1;
            var result = await _handler.Handle(new UpdateRateCommand() { RateDto = _rateDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(2);

        }


    }
}



