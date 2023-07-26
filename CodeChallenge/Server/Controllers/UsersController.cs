using CodeChallenge.Application.Commands;
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


        // GET api/<UsersController>/
        [HttpPost("{userLogin}")]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin)
        {
            var authenticatedUser = await _mediator.Send(new GetUserQuery(userLogin.Username, userLogin.Password));

            if(authenticatedUser != null)
            {
                return Ok(authenticatedUser);
            }

            return Ok(null);
        }

        // POST api/<UsersController>
        [HttpPost("{user}")]
        [Route("signup")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var userCreated = await _mediator.Send(new CreateUserCommand(user));

            if (userCreated > 0)
            {
                return Ok(true);
            }

            return Ok(null);
        }
    }
}
