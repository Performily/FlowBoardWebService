using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Interfaces.REST.Resources;

namespace FlowboardAPI.Workspace.Interfaces.REST.Transform;

public static class EmployeeResourceFromEntityAssembler
{
    public static EmployeeResource ToResourceFromEntity(Employee entity)
    {
        return new EmployeeResource(entity.Id, entity.Name, entity.Code, entity.WorkEmail.Address);
    }
}