using FlowboardAPI.Workspace.Domain.Model.Commands;
using FlowboardAPI.Workspace.Interfaces.REST.Resources;

namespace FlowboardAPI.Workspace.Interfaces.REST.Transform;

public static class CreateEmployeeCommandFromResourceAssembler
{
    public static CreateEmployeeCommand ToCommandFromResource(CreateEmployeeResource resource)
    {
        return new CreateEmployeeCommand(
            resource.Code, resource.Name, resource.CivilStatus, resource.DocumentNumber, 
            resource.Age, resource.PersonalEmail, resource.PhoneNumber, resource.Address, 
            resource.Gender, resource.WorkEmail, resource.HireDate, resource.ContractType, 
            resource.Area, resource.JobPosition, resource.EducationLevel);
    }
}