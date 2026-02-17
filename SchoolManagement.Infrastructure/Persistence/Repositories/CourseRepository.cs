using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly SchoolDbContext _context;
    public CourseRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Course>> GetByLevelAsync(CourseLevel level)
    {
        return await  _context.Courses
            .Where(c => c.CourseLevel == level)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Course>> GetByTeacherIdAsync(int id)
    {
        return await _context.Courses
            .Where(c => c.TeacherId == id)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        return Task.CompletedTask;
    }
}