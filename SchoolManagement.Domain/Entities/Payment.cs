using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities;

public class Payment : BaseEntity
{
    public int StudentId { get; private set; }
    public Student Student { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public PaymentType PaymentType { get; private set; }
    
    private Payment() {}

    public Payment(int studentId, decimal amount, DateTime paymentDate, PaymentType paymentType)
    {
        StudentId = studentId;
        SetAmount(amount);
        SetPaymentDate(paymentDate);
        PaymentStatus = PaymentStatus.Pending;
        PaymentType = paymentType;
        
        SetCreated();
    }

    public void MarkAsPaid()
    {
        if (PaymentStatus == PaymentStatus.Paid)
            throw new InvalidOperationException("Payment is already paid");
        PaymentStatus = PaymentStatus.Paid;
        Touch();
    }
    
    private void SetAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative");
        Amount = amount;
    }

    private void SetPaymentDate(DateTime paymentDate)
    {
        if (paymentDate > DateTime.UtcNow)
            throw new ArgumentException("Payment date cannot be in the future");
        PaymentDate = paymentDate;
    }
}