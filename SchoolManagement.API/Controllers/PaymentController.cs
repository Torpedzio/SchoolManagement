using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Payments.Commands.MarkPaymentAsPaid;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;
    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;    
    }

    [HttpPatch("{id}/mark-as-paid")]
    public async Task<IActionResult> MarkAsPaid(int id)
    {
        await _mediator.Send(new MarkPaymentAsPaidCommand(id));
        return NoContent();
    }
}