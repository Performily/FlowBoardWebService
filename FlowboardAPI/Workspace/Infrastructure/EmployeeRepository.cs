using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Workspace.Infrastructure.Persistence.EFC.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }

    public async Task<Employee?> FindByCodeAsync(string code)
    {
        return await Context.Set<Employee>().FirstOrDefaultAsync(e => e.Code == code);
    }

    public async Task<Employee?> FindByDocumentNumberAsync(string documentNumber)
    {
        return await Context.Set<Employee>().FirstOrDefaultAsync(e => e.DocumentNumber.Number == documentNumber);
    }
}