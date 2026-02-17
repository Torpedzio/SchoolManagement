using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface IApplicationDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<Course> Courses { get; }
    DbSet<Enrollment> Enrollments { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Lesson> Lessons { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken =  default);
}