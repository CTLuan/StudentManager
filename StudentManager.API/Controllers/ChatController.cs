using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Features.Message.Command;

namespace StudentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] SendMessageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpGet("conversation/{userId}")]
        //public async Task<IActionResult> GetConversation(Guid userId)
        //{
            
        //}

    }
}
