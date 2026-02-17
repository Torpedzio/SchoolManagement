using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student?> GetByEmailAsync(string email);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task <bool> ExistsByEmailAsync(string email);
}