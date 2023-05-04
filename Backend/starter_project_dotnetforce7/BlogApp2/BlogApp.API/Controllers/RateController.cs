using API.Controllers;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.API.Controllers
{
    public class RateController : BaseApiController
    {
        [HttpGet] //api/rates
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetRateListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRate(int id)
        {
            return HandleResult(await Mediator.Send(new GetRateDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRate(CreateRateDto rate)
        {
            return HandleResult(await Mediator.Send(new CreateRateCommand{ RateDto  = rate }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRate(UpdateRateDto Rate)
        {
            return HandleResult(await Mediator.Send(new UpdateRateCommand { RateDto = Rate }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActvity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteRateCommand{ Id = id }));
        }
    }
}
