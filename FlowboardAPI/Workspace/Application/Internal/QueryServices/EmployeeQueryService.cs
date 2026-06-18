using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Repositories;
using FlowboardAPI.Workspace.Application.QueryServices;
namespace FlowboardAPI.Workspace.Application.Internal.QueryServices;

public class EmployeeQueryService: IEmployeeQueryService
{
    private readonly IEmployeeRepository _repository;
    public EmployeeQueryService(IEmployeeRepository repository) => _repository = repository;

    public async Task<IEnumerable<Employee>> Handle() => await _repository.ListAsync();
}