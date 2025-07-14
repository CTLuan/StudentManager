using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Features.User.Queries;
using StudentManager.Application.Features.Users.Command;

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

        [HttpPost(Name = "GetUser")]
        public async Task<IActionResult> GetUserbyId(GetUserByIdQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}
