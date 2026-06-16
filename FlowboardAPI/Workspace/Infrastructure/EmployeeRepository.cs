using FlowboardAPI.Shared.Infrastructure.Configuration;
using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Workspace.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
    }

    public async Task<Employee?> FindByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public void Update(Employee entity)
    {
        _context.Employees.Update(entity);
    }

    public void Remove(Employee entity)
    {
        _context.Employees.Remove(entity);
    }

    public async Task<IEnumerable<Employee>> ListAsync()
    {
        return await _context.Employees.ToListAsync();
    }


    public async Task<Employee?> FindByCodeAsync(string code)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Code == code);
    }

    public async Task<Employee?> FindByDocumentNumberAsync(string documentNumber)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.DocumentNumber.Number == documentNumber);
    }
}