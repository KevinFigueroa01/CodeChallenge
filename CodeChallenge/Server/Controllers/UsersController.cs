﻿using CodeChallenge.Application.Commands;
using CodeChallenge.Application.Queries;
using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Shared.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // POST api/<UsersController>/
        [HttpPost("{userLogin}")]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin)
        {
            var authenticatedUser = await _mediator.Send(new GetUserQuery(userLogin.Email, userLogin.Password));

            return Ok(authenticatedUser);
        }

        // POST api/<UsersController>
        [HttpPost("{user}")]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignupDto userSignup)
        {
            var user = userSignup.ToUser();
            var userCreated = await _mediator.Send(new CreateUserCommand(user));

            if (userCreated > 0)
            {
                return Ok(user);
            }

            return Ok(null);
        }

        // GET api/<UsersController>
        [HttpGet("{email}")]
        [Route("getByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var user = await _mediator.Send(new GetUserByEmailQuery(email));

            if (user != null)
            {
                return Ok(true);
            }

            return Ok(false);
        }

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string email)
        {
            var result = await _mediator.Send(new DeleteUserCommand(email));

            if (result > 0)
            {
                return Ok(true);
            }

            return Ok(false);
        }

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            var result = await _mediator.Send(new UpdateUserCommand(user));

            if (result > 0)
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
