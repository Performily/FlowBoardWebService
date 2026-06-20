using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Workspace.Domain.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee?> FindByCodeAsync(string code);
    Task<Employee?> FindByDocumentNumberAsync(string documentNumber);
}