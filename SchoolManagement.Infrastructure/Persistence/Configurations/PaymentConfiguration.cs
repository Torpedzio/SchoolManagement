using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.StudentId)
            .IsRequired();
        
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasPrecision(10, 2);
        
        builder.Property(x => x.PaymentDate)
            .IsRequired();

        builder.Property(x => x.PaymentStatus)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.PaymentType)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired();
        
        
        builder.HasIndex(x => x.StudentId);
        
        builder.HasIndex(x => x.PaymentStatus);
        
        builder.HasIndex(x => x.PaymentDate);
        
        
        builder.HasOne(x => x.Student)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
    
}