namespace FlowboardAPI.Workspace.Domain.Model.Commands;

public record CreateEmployeeCommand(
    string Code, string Name, string CivilStatus, string DocumentNumber, 
    int Age, string PersonalEmail, string PhoneNumber, string Address, 
    string Gender, string WorkEmail, DateTime HireDate, string ContractType, 
    string Area, string JobPosition, string EducationLevel);