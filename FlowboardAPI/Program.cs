using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString!))
);

builder.Services.AddScoped<FlowboardAPI.Workspace.Domain.Repositories.IEmployeeRepository, FlowboardAPI.Workspace.Infrastructure.Repositories.EmployeeRepository>();

builder.Services.AddOpenApi();

builder.Services.AddControllers(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();