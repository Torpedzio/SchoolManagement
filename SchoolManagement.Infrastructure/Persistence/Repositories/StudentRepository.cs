using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolDbContext _context;
    public StudentRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student?> GetByEmailAsync(string email)
    {
        return await _context.Students
            .FirstOrDefaultAsync(s => s.Email == email);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        return Task.CompletedTask;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Students
            .AnyAsync(s => s.Email == email);
    }
}