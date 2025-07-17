using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Features.Auth.Query;

namespace StudentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] LoginQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        [Authorize]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
