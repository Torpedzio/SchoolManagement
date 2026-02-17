using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Payments.Commands.MarkPaymentAsPaid;

public class MarkPaymentAsPaidCommandHandler : IRequestHandler<MarkPaymentAsPaidCommand, Unit>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IApplicationDbContext _context;

    public MarkPaymentAsPaidCommandHandler(IPaymentRepository paymentRepository, IApplicationDbContext context)
    {
        _paymentRepository = paymentRepository;
        _context = context;
    }
    
    public async Task<Unit> Handle(MarkPaymentAsPaidCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.PaymentId);
        if(payment is null)
            throw new KeyNotFoundException($"Payment with id {request.PaymentId} not found");
        
        payment.MarkAsPaid();
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}