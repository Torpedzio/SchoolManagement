using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");
        builder.HasKey(x => x.Id);
        
        
        builder.Property(x => x.CourseId)
            .IsRequired();
        
        builder.Property(x => x.TeacherId)
            .IsRequired();
        
        builder.Property(x => x.Date)
            .IsRequired();
        
        builder.Property(x => x.DurationTime)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Room)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LessonStatus)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired();


        builder.HasIndex(x => x.CourseId);
        builder.HasIndex(x => x.Date);
        builder.HasIndex(x => x.LessonStatus);
        builder.HasIndex(x => new { x.CourseId, x.Date });

        
        
        builder.HasOne(x => x.Course)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}