using LMS.Application.Features.Tests.Commands;
using LMS.Application.Features.Tests.DTOs;
using LMS.Application.Features.Tests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers;

[ApiController]
[Route("api/courses/{courseId}/[controller]")]
[Authorize]
public class TestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/courses/1/tests
    [HttpGet]
    public async Task<IActionResult> GetTests(int courseId)
    {
        var tests = await _mediator.Send(
            new GetTestsByCourseQuery
            {
                CourseId = courseId
            });

        return Ok(tests);
    }

    // POST: api/courses/1/tests
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTest(
        int courseId,
        [FromBody] TestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateTestCommand
        {
            CourseId = courseId,
            QuestionText = dto.QuestionText!,
            Options = dto.Options!,
            CorrectAnswer = dto.CorrectAnswer!
        };

        var testId = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetTests),
            new { courseId },
            new { TestId = testId });
    }

    // PUT: api/courses/1/tests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTest(
        int courseId,
        int id,
        [FromBody] TestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new UpdateTestCommand
        {
            TestId = id,
            CourseId = courseId,
            QuestionText = dto.QuestionText!,
            Options = dto.Options!,
            CorrectAnswer = dto.CorrectAnswer!
        };

        var success = await _mediator.Send(command);

        if (!success)
            return NotFound(new { Message = "Test not found." });

        return NoContent();
    }

    // DELETE: api/courses/1/tests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        var command = new DeleteTestCommand
        {
            TestId = id
        };

        var success = await _mediator.Send(command);

        if (!success)
            return NotFound(new { Message = "Test not found." });

        return NoContent();
    }
}