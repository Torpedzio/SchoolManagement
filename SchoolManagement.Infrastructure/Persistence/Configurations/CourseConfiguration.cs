using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.CourseName)
            .HasMaxLength(100);
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.CourseLevel)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.PricePerHour)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Property(x => x.MaxStudents)
            .IsRequired();
        
        builder.Property(x => x.TeacherId)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired();


        builder.HasIndex(x => x.TeacherId);
        
        
        builder.HasMany(x => x.Enrollments)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.Lessons)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}