namespace FlowboardAPI.Workspace.Interfaces.REST.Resources;
public record EmployeeResource(
    int Id, 
    string Name, 
    string Code, 
    string Email,
    string Address,
    int Age,
    string Area,
    string JobPosition,
    string ContractType,
    string Status
);