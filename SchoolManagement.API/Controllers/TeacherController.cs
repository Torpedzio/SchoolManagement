using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Teachers.Command.CreateTeacher;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/teacher")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherCommand command)
    {
        var teacherId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = teacherId }, teacherId);
    }
}