using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task<List<Course>> GetByLevelAsync(CourseLevel level);
    Task<List<Course>> GetByTeacherIdAsync(int teacherId);
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);
}