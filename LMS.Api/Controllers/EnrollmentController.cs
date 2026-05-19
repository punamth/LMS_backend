using LMS.Application.Features.Enrollment.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("api/courses/{courseId}/[controller]")]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/courses/{courseId}/enrollment
        [HttpPost]
        public async Task<IActionResult> Enroll(int courseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized(new { Message = "Invalid token" });

            await _mediator.Send(new EnrollCourseCommand
            {
                CourseId = courseId,
                UserId = userId
            });

            return Ok(new { Message = "Enrolled successfully" });
        }

        // DELETE: api/courses/{courseId}/enrollment
        [HttpDelete]
        public async Task<IActionResult> Unenroll(int courseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized(new { Message = "Invalid token" });

            await _mediator.Send(new DeleteEnrollmentCommand
            {
                CourseId = courseId,
                UserId = userId
            });

            return Ok(new { Message = "Unenrolled successfully" });
        }
    }
}
