using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Shared.Infrastructure.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Employee>().ToTable("employees");
        builder.Entity<Employee>().HasKey(e => e.Id);

    
        builder.Entity<Employee>().OwnsOne(e => e.PersonalEmail, email => 
        {
            email.Property(p => p.Address).HasColumnName("personal_email");
        });

        builder.Entity<Employee>().OwnsOne(e => e.WorkEmail, email => 
        {
            email.Property(p => p.Address).HasColumnName("work_email");
        });

        builder.Entity<Employee>().OwnsOne(e => e.DocumentNumber, doc => 
        {
            doc.Property(p => p.Number).HasColumnName("document_number");
        });
    }
}