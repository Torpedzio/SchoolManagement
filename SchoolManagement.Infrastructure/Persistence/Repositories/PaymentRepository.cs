using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly SchoolDbContext _context;
    public PaymentRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await _context.Payments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Payment>> GetByStudentIdAsync(int id)
    {
        return await _context.Payments
            .AsNoTracking()
            .Where(p => p.StudentId == id)
            .ToListAsync();
    }

    public async Task<List<Payment>> GetByPaymentStatusAsync(PaymentStatus status)
    {
        return await _context.Payments
            .AsNoTracking()
            .Where(p => p.PaymentStatus == status)
            .ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        return Task.CompletedTask;
    }
}