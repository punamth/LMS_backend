using LMS.Application.Features.Auth.DTOs;
using LMS.Application.Features.Auth.Commands;
using LMS.Application.Features.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]                         // Secure all endpoints by default
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/auth/register
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var userDto = await _mediator.Send(command);
            return Ok(userDto);
        }

        // POST api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);

                if (string.IsNullOrEmpty(token))
                    return Unauthorized(new { Message = "Invalid email or password." });

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                // Only map explicit auth failures to 401
                return Unauthorized(new { ex.Message });
            }
            // All other exceptions propagate to the global error handler
        }

        // GET api/auth/users  —  Admin only
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        // GET api/auth/users/{id}  —  Owner or Admin
        [HttpGet("users/{id:int}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Allow if caller is an Admin, or if caller is requesting their own profile
            var callerId = int.TryParse(
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
                out var parsedId) ? parsedId : -1;

            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && callerId != id)
                return Forbid();

            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });

            if (user is null)
                return NotFound(new { Message = "User not found." });

            return Ok(user);
        }

        // DELETE api/auth/users/{id}  —  Admin only
        [HttpDelete("users/{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { UserId = id });

            if (!result)
                return NotFound(new { Message = "User not found." });

            return Ok(new { Message = "User deleted successfully." });
        }
    }
}