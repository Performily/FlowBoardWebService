using Microsoft.EntityFrameworkCore;
using FlowboardAPI.Attendance.Domain.Model.Aggregates;

namespace FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAttendanceConfiguration(this ModelBuilder builder)
    {
        builder.Entity<AttendanceRecord>().HasKey(a => a.Id);
        builder.Entity<AttendanceRecord>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd(); 
        
        builder.Entity<AttendanceRecord>().Property(a => a.EmployeeId).IsRequired();
        builder.Entity<AttendanceRecord>().Property(a => a.Timestamp).IsRequired();
        
        builder.Entity<AttendanceRecord>().Property(a => a.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Entity<AttendanceRecord>().OwnsOne(a => a.BiometricId, b =>
        {
            b.WithOwner();
            b.Property(p => p.Value).HasColumnName("BiometricId").IsRequired().HasMaxLength(50);
        });
    }
}