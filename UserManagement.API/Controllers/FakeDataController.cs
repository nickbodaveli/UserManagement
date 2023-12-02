using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Management.Queries.FakeUserQueries;

namespace UserManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataController : ControllerBase
    {
        private readonly ISender _mediator;

        public FakeDataController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("FakeUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var request = new GetFakeUsersQuery()
            {
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("FakeUserPostWithComments")]
        public async Task<IActionResult> PostWithComments(int userId)
        {
            var request = new GetFakePostQuery()
            {
                UserId = userId
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpGet("FakeTodos")]
        public async Task<IActionResult> Todos(int userId)
        {
            var request = new GetFakeUserTodo()
            {
                UserId = userId
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("FakeAlbums")]
        public async Task<IActionResult> Albums(int userId)
        {
            var request = new GetFakeUserAlbumsQuery()
            {
                UserId = userId
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
