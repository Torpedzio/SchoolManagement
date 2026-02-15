using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Infrastructure.Persistence;

public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
{
    public SchoolDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
        var connectionString =
            "Host=db.lmnpyswhpjsopjvffrzh.supabase.co;Database=postgres;Username=postgres;Password=[SxNE7nvMXZPJpPKi];SSL Mode=Require;Trust Server Certificate=true";
        
        optionsBuilder.UseNpgsql(connectionString);
        
        return new SchoolDbContext(optionsBuilder.Options);
    }
}