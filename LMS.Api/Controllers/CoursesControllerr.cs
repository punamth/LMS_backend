using LMS.Application.Features.Courses.Commands;
using LMS.Application.Features.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/courses
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _mediator.Send(new GetCoursesQuery());
        return Ok(courses);
    }

    // GET: api/courses/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery { Id = id });
        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // POST: api/courses
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateCourse([FromForm] CreateCourseCommand command)
    {
        var courseDto = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCourseById), new { id = courseDto.CourseId }, courseDto);
    }

    // PUT: api/courses/{id}
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")] // allow thumbnail update
    public async Task<IActionResult> UpdateCourse(int id, [FromForm] UpdateCourseCommand command)
    {
        if (id != command.Id)
            return BadRequest("Course ID mismatch.");

        var updatedCourse = await _mediator.Send(command);
        if (updatedCourse == null)
            return NotFound();

        return Ok(updatedCourse);
    }

    // DELETE: api/courses/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var result = await _mediator.Send(new DeleteCourseCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }
}
