using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Model.Queries;
namespace FlowboardAPI.Workspace.Application.QueryServices;

public interface IEmployeeQueryService
{
    Task<IEnumerable<Employee>> Handle();
    Task<Employee?> Handle(GetEmployeeByIdQuery query);
}