using MediatR;

namespace SchoolManagement.Application.Payments.Commands.MarkPaymentAsPaid;

public record MarkPaymentAsPaidCommand(int PaymentId): IRequest<Unit>;