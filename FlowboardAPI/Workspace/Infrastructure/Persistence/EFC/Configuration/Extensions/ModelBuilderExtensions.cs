using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Workspace.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void AddWorkspaceConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Employee>().ToTable("employees");
        builder.Entity<Employee>().HasKey(e => e.Id);
        
        builder.Entity<Employee>().OwnsOne(e => e.DocumentNumber, d => d.Property(p => p.Number).HasColumnName("document_number"));
        builder.Entity<Employee>().OwnsOne(e => e.PersonalEmail, d => d.Property(p => p.Address).HasColumnName("personal_email"));
        builder.Entity<Employee>().OwnsOne(e => e.WorkEmail, d => d.Property(p => p.Address).HasColumnName("work_email"));
    }
}