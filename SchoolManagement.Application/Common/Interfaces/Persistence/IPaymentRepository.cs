using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface IPaymentRepository
{
    Task<List<Payment>> GetAllAsync();
    Task<Payment?> GetByIdAsync(int id);
    Task<List<Payment>> GetByStudentIdAsync(int studentId);
    Task<List<Payment>> GetByPaymentStatusAsync(PaymentStatus paymentStatus);
    Task AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
}