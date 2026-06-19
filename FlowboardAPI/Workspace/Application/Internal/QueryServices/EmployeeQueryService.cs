using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Repositories;
using FlowboardAPI.Workspace.Application.QueryServices;
using FlowboardAPI.Workspace.Domain.Model.Queries;

namespace FlowboardAPI.Workspace.Application.Internal.QueryServices;

public class EmployeeQueryService : IEmployeeQueryService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeQueryService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }


    public async Task<IEnumerable<Employee>> Handle()
    {
        return await _employeeRepository.ListAsync();
    }

    public async Task<Employee?> Handle(GetEmployeeByIdQuery query)
    {
        return await _employeeRepository.FindByIdAsync(query.Id);
    }
}