using FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions; //del modulo de asistencia
//using FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
//using FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Payroll.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions; // módulo de payroll

using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
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
        
        builder.ApplyPayrollConfiguration();
        
        builder.UseSnakeCaseNamingConvention();
    }
}