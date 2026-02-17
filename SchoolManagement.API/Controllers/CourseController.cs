using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Application.Courses.Commands.CreateCourse;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public  CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseCommand command)
    {
        var courseId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create),new {id = courseId}, courseId);
    }
}