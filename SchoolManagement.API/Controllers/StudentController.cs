using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Students.Commands.CreateStudent;
using SchoolManagement.Application.Students.Commands.DeactiveStudent;
using SchoolManagement.Application.Students.Queries.GetStudentById;
using SchoolManagement.Application.Students.Queries.GetStudentDashboard;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
    {
        var studentId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { studentId }, studentId);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));

        return Ok(student);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await _mediator.Send(new DeactiveStudentCommand(id));
        return NoContent();
    }

    [HttpGet("{id:int}/dashboard")]
    public async Task<IActionResult> GetDashboard(int id)
    {
        var result = await _mediator.Send(new GetStudentDashboardQuery(id));
        return Ok(result);
    }
}