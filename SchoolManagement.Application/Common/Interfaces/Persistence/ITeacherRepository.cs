using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int teacherId);
    Task<List<Teacher>> GetByLastNameAsync(string lastName);
    Task<Teacher?> GetByEmailAsync(string email);
    Task<List<Teacher>> GetByInstrumentAsync(Instrument instrument);
    Task AddAsync(Teacher teacher);
    Task UpdateAsync(Teacher teacher);
}