using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly SchoolDbContext _context;
    public EnrollmentRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        return await _context.Enrollments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _context.Enrollments
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Enrollment>> GetByStudentIdAsync(int id)
    {
        return await  _context.Enrollments
            .AsNoTracking()
            .Where(e => e.StudentId == id)
            .ToListAsync();
    }

    public async Task<List<Enrollment>> GetByCourseIdAsync(int id)
    {
        return await _context.Enrollments
            .AsNoTracking()
            .Where(e => e.CourseId == id)
            .ToListAsync();
    }

    public async Task<List<Enrollment>> GetByEnrollmentStatusAsync(EnrollmentStatus status)
    {
        return await _context.Enrollments
            .AsNoTracking()
            .Where(e => e.EnrollmentStatus == status)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int studentId, int courseId)
    {
        return await _context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }

    public async Task AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
    }

    public Task UpdateAsync(Enrollment enrollment)
    {
        _context.Enrollments.Update(enrollment);
        return Task.CompletedTask;
    }
}