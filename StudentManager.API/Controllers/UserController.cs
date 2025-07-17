using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Features.User.Queries;
using StudentManager.Application.Features.Users.Command;
using StudentManager.Application.Features.Users.Queries;

namespace StudentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUserbyId([FromQuery] GetUserByIdQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());
            return Ok(result);
        }

    }
}
