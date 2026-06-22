using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Interfaces.REST.Resources;

namespace FlowboardAPI.Workspace.Interfaces.REST.Transform;

public static class EmployeeResourceFromEntityAssembler
{
    public static EmployeeResource ToResourceFromEntity(Employee entity)
    {
        return new EmployeeResource(
            entity.Id,
            entity.Code,
            entity.Name,
            entity.DocumentNumber.Number,      
            entity.PersonalEmail.Address,    
            entity.WorkEmail.Address,         
            entity.CivilStatus,
            entity.Age,
            entity.PhoneNumber,
            entity.Address,
            entity.Gender,
            entity.HireDate,
            entity.ContractType,
            entity.Area,
            entity.JobPosition,
            entity.Status,
            entity.EducationLevel,
            entity.AvailableDays);
    }
}