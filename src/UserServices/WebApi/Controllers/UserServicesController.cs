using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.CQRS.Command.Create;
using UserService.Application.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var command = new CreateUserCommand { createUser = createUserDto };
            var result = await _mediator.Send(command);

            if (!result.IsSuccesful)
            {
                return BadRequest(result.ErrorMsg);
            }

            return Ok(result);
        }
    }
}
