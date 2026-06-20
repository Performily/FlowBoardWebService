using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Model.Commands;

namespace FlowboardAPI.Workspace.Application.CommandServices;

public interface IEmployeeCommandService
{
    Task<Employee?> Handle(CreateEmployeeCommand command);
}