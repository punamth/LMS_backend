using LMS.Application.Features.Progress.Commands;
using LMS.Application.Features.Progress.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers;

[ApiController]
[Route("api/users/{userId}/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProgressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProgress(int userId)
    {
        var progress = await _mediator.Send(new GetUserProgressQuery { UserId = userId });
        return Ok(progress);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProgress(int userId, [FromBody] UpdateProgressCommand command)
    {
        command.UserId = userId;
        await _mediator.Send(command);
        return NoContent();
    }
}
