using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Infrastructure.Persistence;

public class SchoolDbContext :DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {
        
    }
}