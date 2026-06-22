namespace FlowboardAPI.Workspace.Interfaces.REST.Resources;
public record EmployeeResource(
    int Id,
    string Code,
    string Name,
    string DocumentNumber,
    string PersonalEmail,
    string WorkEmail,
    string CivilStatus,
    int Age,
    string PhoneNumber,
    string Address,
    string Gender,
    DateTime HireDate,
    string ContractType,
    string Area,
    string JobPosition,
    string Status,
    string EducationLevel,
    int AvailableDays
);