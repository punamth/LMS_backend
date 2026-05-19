using LMS.Application.Features.Lessons.Commands;
using LMS.Application.Features.Lessons.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers;

[ApiController]
[Route("api/courses/{courseId}/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LessonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/courses/{courseId}/lessons
    [HttpGet]
    public async Task<IActionResult> GetLessons(int courseId)
    {
        var lessons = await _mediator.Send(new GetLessonsByCourseQuery { CourseId = courseId });
        return Ok(lessons);
    }

    // POST: api/courses/{courseId}/lessons
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddLesson(int courseId, [FromForm] CreateLessonCommand command)
    {
        command.CourseId = courseId;

        var lessonDto = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetLessons),
            new { courseId = courseId },
            lessonDto);
    }

    // PUT: api/courses/{courseId}/lessons/{lessonId}
    [HttpPut("{lessonId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateLesson(int courseId, int lessonId, [FromForm] UpdateLessonCommand command)
    {
        if (lessonId != command.LessonId)
            return BadRequest("Lesson ID mismatch.");

        // Ensure courseId is preserved (optional, if needed)
        command.LessonId = lessonId;

        var updatedLesson = await _mediator.Send(command);
        if (updatedLesson == null)
            return NotFound();

        return Ok(updatedLesson);
    }

    // DELETE: api/courses/{courseId}/lessons/{lessonId}
    [HttpDelete("{lessonId}")]
    public async Task<IActionResult> DeleteLesson(int courseId, int lessonId)
    {
        var result = await _mediator.Send(new DeleteLessonCommand { LessonId = lessonId });
        if (!result)
            return NotFound();

        return NoContent();
    }
}
