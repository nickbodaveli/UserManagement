using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Management.Commands.Authentication;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Token")]
        public async Task<IActionResult> GetToken(LoginCommand request)
        {
            LoginDataValidation validation = new LoginDataValidation();
            var validator = validation.Validate(request);

            if (!validator.IsValid)
            {
                return Ok(validator.Errors);
            }
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
