using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private  readonly SchoolDbContext _context;
    public TeacherRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _context.Teachers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    
    public async Task<List<Teacher>> GetByLastNameAsync(string lastName)
    {
        return await _context.Teachers
            .Where(t => t.LastName == lastName)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Teacher?> GetByEmailAsync(string email)
    {
        return await _context.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Email == email);
    }

    public async Task<List<Teacher>> GetByInstrumentAsync(Instrument instrument)
    {
        return await _context.Teachers
            .Where(t => t.Instrument == instrument)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
    }

    public Task UpdateAsync(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        return Task.CompletedTask;
    }
}