using FlowboardAPI.Shared.Infrastructure.Interfaces.AspNetCore.Configuration;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using FlowboardAPI.Shared.Infrastructure.Pipeline.Middleware.Extensions;
using FlowboardAPI.Shared.Resources.Errors;
using FlowboardAPI.Shared.Resources;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi; 

using ProblemDetailsFactory = FlowboardAPI.Shared.Interfaces.Rest.ProblemDetails.ProblemDetailsFactory;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE RUTAS Y CONTROLADORES
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddDataAnnotationsLocalization();

builder.Services.AddProblemDetails();

// 2. CONFIGURACIÓN DE CORS (Para que React/Angular se puedan conectar después)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// 3. CONEXIÓN A LA BASE DE DATOS MYSQL
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionStringTemplate))
        throw new InvalidOperationException("Database connection string is not set in the configuration.");

    var connectionString = Environment.ExpandEnvironmentVariables(connectionStringTemplate);
    
    // Cambiado a UseMySQL o UseMySql según la librería de tu clase
    options.UseMySQL(connectionString)
        .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
        .EnableDetailedErrors();

    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});

// 4. LOCALIZACIÓN E IDIOMAS
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton<IStringLocalizer<ErrorMessages>, StringLocalizer<ErrorMessages>>();
builder.Services.AddSingleton<IStringLocalizer<CommonMessages>, StringLocalizer<CommonMessages>>();
builder.Services.AddSingleton<ProblemDetailsFactory>();

// 5. SWAGGER (DOCUMENTACIÓN DE LA API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Flowboard API", Version = "v1" });
    options.EnableAnnotations();
});

// 6. MEDIATOR (CORTEX)
builder.Services.AddCortexMediator([typeof(Program)]);

var app = builder.Build();

// 7. MIGRACIONES AUTOMÁTICAS
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// 8. MIDDLEWARES (PIPELINE)
app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();