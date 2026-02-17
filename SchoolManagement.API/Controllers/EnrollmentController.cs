using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Enrollments.Commands.EnrollStudentToCourse;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/enrollments")]
public class EnrollmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnrollmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollStudentToCourseCommand command)
    {
        var enrollmentId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Enroll),new {id = enrollmentId }, enrollmentId);
    }
}