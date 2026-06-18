using FlowboardAPI.Workspace.Domain.Model.Aggregates;

namespace FlowboardAPI.Workspace.Application.QueryServices;

public interface IEmployeeQueryService
{
    Task<IEnumerable<Employee>> Handle();
}