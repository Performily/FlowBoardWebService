using Microsoft.EntityFrameworkCore;
using FlowboardAPI.Requests.Domain.Model.Aggregates;

namespace FlowboardAPI.Requests.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyRequestConfiguration(this ModelBuilder builder)
    {
        builder.Entity<RequestRecord>().HasKey(r => r.Id);
        builder.Entity<RequestRecord>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<RequestRecord>().Property(r => r.EmployeeId).IsRequired();
        builder.Entity<RequestRecord>().Property(r => r.CreatedAt).IsRequired();

        builder.Entity<RequestRecord>().Property(r => r.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Entity<RequestRecord>().Property(r => r.Status)
            .HasConversion<string>()
            .IsRequired();

        // Mapeo de Value Objects corrigiendo la llave foránea
        builder.Entity<RequestRecord>().OwnsOne(r => r.Justification, j =>
        {
            j.WithOwner().HasForeignKey("Id");
            j.Property(p => p.Reason).HasColumnName("JustificationReason").IsRequired();
        });

        builder.Entity<RequestRecord>().OwnsOne(r => r.Evidence, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(p => p.DocumentUrl).HasColumnName("EvidenceUrl");
        });

        builder.Entity<RequestRecord>().OwnsOne(r => r.Period, p =>
        {
            p.WithOwner().HasForeignKey("Id");
            p.Property(x => x.StartDate).HasColumnName("PeriodStartDate");
            p.Property(x => x.EndDate).HasColumnName("PeriodEndDate");
            p.Property(x => x.TotalDays).HasColumnName("PeriodTotalDays");
        });

        builder.Entity<RequestRecord>().OwnsOne(r => r.TimeFrame, t =>
        {
            t.WithOwner().HasForeignKey("Id");
            t.Property(x => x.Date).HasColumnName("TimeFrameDate");
            t.Property(x => x.StartTime).HasColumnName("TimeFrameStartTime");
            t.Property(x => x.EndTime).HasColumnName("TimeFrameEndTime");
            t.Property(x => x.TotalHours).HasColumnName("TimeFrameTotalHours");
        });

        builder.Entity<RequestRecord>().OwnsOne(r => r.ReviewDetails, rd =>
        {
            rd.WithOwner().HasForeignKey("Id");
            rd.Property(x => x.ReviewerId).HasColumnName("ReviewerId");
            rd.Property(x => x.ReviewedAt).HasColumnName("ReviewedAt");
            rd.Property(x => x.RejectionReason).HasColumnName("RejectionReason");
        });
    }
}