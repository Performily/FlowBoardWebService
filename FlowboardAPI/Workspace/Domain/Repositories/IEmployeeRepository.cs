using FlowboardAPI.Shared.Domain.Repositories;
using FlowboardAPI.Workspace.Domain.Model.Aggregates;

namespace FlowboardAPI.Workspace.Domain.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee?> FindByCodeAsync(string code);
    Task<Employee?> FindByDocumentNumberAsync(string documentNumber);
}