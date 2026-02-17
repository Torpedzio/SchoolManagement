using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface IEnrollmentRepository
{
    Task<List<Enrollment>> GetAllAsync();
    Task<Enrollment?> GetByIdAsync(int id);
    Task<List<Enrollment>> GetByStudentIdAsync(int studentId);
    Task<List<Enrollment>> GetByCourseIdAsync(int courseId);
    Task<List<Enrollment>> GetByEnrollmentStatusAsync(EnrollmentStatus status);
    Task<bool> ExistsAsync(int studentId, int courseId);
    Task AddAsync(Enrollment enrollment);
    Task UpdateAsync(Enrollment enrollment);
}