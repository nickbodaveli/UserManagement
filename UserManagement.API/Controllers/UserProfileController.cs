using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Management.Commands.UsersProfileCommands;
using UserManagement.Application.Management.Queries.UsersProfileQueries;

namespace UserManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ISender _mediator;

        public UserProfileController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProfile(CreateUserProfileCommand request)
        {
            UserProfileValidation validation = new UserProfileValidation();
            var validator = validation.Validate(request);
            if (!validator.IsValid)
            {
                return Ok(validator.Errors);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetProfiles()
        {
            var request = new UserProfilesQuery();

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new UserProfileQuery()
            {
                Id = id
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserProfileCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(RemoveUserProfileCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
