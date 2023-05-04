﻿using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<_UserDto>>> Get()
        {
            var users = await _mediator.Send(new Get_UserListQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<_UserDto>> Get(int id)
        {
            var users = await _mediator.Send(new Get_UserDetailQuery { Id = id });
            return Ok(users);
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] _UserDto userDto)
        {
            var command = new Update_UserCommand { _UserDto = userDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new Delete_UserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
