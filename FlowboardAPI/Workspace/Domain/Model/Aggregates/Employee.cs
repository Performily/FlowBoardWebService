using FlowboardAPI.Shared.Domain.Model.Entities;
using FlowboardAPI.Workspace.Domain.Model.ValueObjects;

namespace FlowboardAPI.Workspace.Domain.Model.Aggregates;

public partial class Employee : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public int Id { get; private set; }
    public string Code { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;


    public DocumentNumber DocumentNumber { get; private set; } = new DocumentNumber("00000000");
    public EmailAddress PersonalEmail { get; private set; } = new EmailAddress("default@email.com");
    public EmailAddress WorkEmail { get; private set; } = new EmailAddress("default@work.com");


    public string CivilStatus { get; private set; } = string.Empty;
    public int Age { get; private set; }
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public DateTime HireDate { get; private set; }
    public string ContractType { get; private set; } = string.Empty;
    public string Area { get; private set; } = string.Empty;
    public string JobPosition { get; private set; } = string.Empty;
    public string Status { get; private set; } = "ACTIVE";
    public string EducationLevel { get; private set; } = string.Empty;
    public int AvailableDays { get; private set; }


    protected Employee() { } 

    public Employee(string code, string name, string civilStatus, DocumentNumber documentNumber, 
                    int age, EmailAddress personalEmail, string phoneNumber, string address, 
                    string gender, EmailAddress workEmail, DateTime hireDate, string contractType, 
                    string area, string jobPosition, string educationLevel)
    {
        Code = code;
        Name = name;
        CivilStatus = civilStatus;
        DocumentNumber = documentNumber;
        Age = age;
        PersonalEmail = personalEmail;
        PhoneNumber = phoneNumber;
        Address = address;
        Gender = gender;
        WorkEmail = workEmail;
        HireDate = hireDate;
        ContractType = contractType;
        Area = area;
        JobPosition = jobPosition;
        Status = "ACTIVE"; 
        EducationLevel = educationLevel;
        AvailableDays = 0;
    }
}