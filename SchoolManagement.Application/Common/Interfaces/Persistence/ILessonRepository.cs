using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface ILessonRepository
{
    Task<List<Lesson>> GetAllAsync();
    Task<Lesson?> GetByIdAsync(int id);
    Task<List<Lesson>> GetByCourseIdAsync(int courseId);
    Task<List<Lesson>> GetByTeacherIdAsync(int teacherId);
    Task<List<Lesson>> GetByDurationTimeAsync(DurationTime durationTime);
    Task<List<Lesson>> GetByLessonStatusAsync(LessonStatus status);
    Task AddAsync(Lesson lesson);
    Task UpdateAsync(Lesson lesson);
}