using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Persistence.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly SchoolDbContext _context;
    public LessonRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Lesson>> GetAllAsync()
    {
        return await _context.Lessons
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Lesson?> GetByIdAsync(int id)
    {
        return await _context.Lessons
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<List<Lesson>> GetByCourseIdAsync(int id)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(l => l.CourseId == id)
            .ToListAsync();
    }

    public async Task<List<Lesson>> GetByTeacherIdAsync(int id)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(l => l.TeacherId == id)
            .ToListAsync();
    }

    public async Task<List<Lesson>> GetByDurationTimeAsync(DurationTime durationTime)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(l => l.DurationTime == durationTime)
            .ToListAsync();
    }

    public async Task<List<Lesson>> GetByLessonStatusAsync(LessonStatus status)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(l => l.LessonStatus == status)
            .ToListAsync();
    }

    public async Task AddAsync(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
    }

    public Task UpdateAsync(Lesson lesson)
    {
        _context.Lessons.Update(lesson);
        return Task.CompletedTask;
    }
}