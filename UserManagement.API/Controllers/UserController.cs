using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Management.Commands.UsersCommands.Register;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;

        public UserController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
