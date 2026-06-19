using FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions; //del modulo de asistencia
//using FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
//using FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Workspace.Infrastructure.Persistence.EFC.Configuration.Extensions;

//using FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
//using FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Requests.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<RequestRecord> RequestRecords { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.ApplyAttendanceConfiguration();
        builder.ApplyAttendanceConfiguration(); //modulo de aistencia
        builder.ApplyRequestConfiguration();
        builder.ApplyIamConfiguration();        //modulo de iam
        builder.UseSnakeCaseNamingConvention();

        builder.AddWorkspaceConfiguration();
    }

    
}