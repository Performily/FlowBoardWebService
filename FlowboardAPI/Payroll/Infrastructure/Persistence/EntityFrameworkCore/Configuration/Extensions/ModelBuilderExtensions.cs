using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Payroll.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPayrollConfiguration(this ModelBuilder builder)
    {
        builder.Entity<PaySlip>().HasKey(paySlip => paySlip.Id);
        builder.Entity<PaySlip>().Property(paySlip => paySlip.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<PaySlip>().Property(paySlip => paySlip.CollaboratorId).IsRequired();

        builder.Entity<PaySlip>().Property(paySlip => paySlip.CollaboratorName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.CollaboratorCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.Area)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.Period)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.PaymentType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.GrossIncome)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.Deductions)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Entity<PaySlip>().Property(paySlip => paySlip.IssueDate).IsRequired();
        builder.Entity<PaySlip>().Property(paySlip => paySlip.PaymentDate).IsRequired(false);

        builder.Entity<PaySlip>().Property(paySlip => paySlip.PdfFileName)
            .IsRequired(false)
            .HasMaxLength(255);
    }
}