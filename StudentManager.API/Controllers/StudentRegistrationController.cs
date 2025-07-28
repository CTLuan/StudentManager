using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Features.StudentRegistration.Command;

namespace StudentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentRegistrationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create-student-registration")]
        public async Task<IActionResult> CreateStudentRegistration([FromForm] CreateStudentRegistrationCommand command)
        {
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { Message = "Failed to create student registration." });
            }
        }
    }
}
