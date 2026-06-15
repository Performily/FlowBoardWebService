using FlowboardAPI.Shared.Domain.Model;
using FlowboardAPI.Workspace.Domain.Model.ValueObjects;

namespace FlowboardAPI.Workspace.Domain.Model.Aggregates;

public partial class Employee : IAuditableEntity
{
    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }

    public DocumentNumber DocumentNumber { get; private set; }
    public EmailAddress PersonalEmail { get; private set; }
    public EmailAddress WorkEmail { get; private set; }

    public string CivilStatus { get; private set; }
    public int Age { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string Gender { get; private set; }
    public DateTime HireDate { get; private set; }
    public string ContractType { get; private set; }
    public string Area { get; private set; }
    public string JobPosition { get; private set; }
    public string Status { get; private set; }
    public string EducationLevel { get; private set; }
    public int AvailableDays { get; private set; }
    
    public string? TerminationReason { get; private set; }
    public string? TerminationObservation { get; private set; }
    public string? TerminationDocuments { get; private set; }
    public DateTime? TerminatedAt { get; private set; }
    public DateTime? ReactivatedAt { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    protected Employee() { }

    public Employee(string code, string name, string civilStatus, 
                    DocumentNumber documentNumber, int age, 
                    EmailAddress personalEmail, string phoneNumber, 
                    string address, string gender, 
                    EmailAddress workEmail, DateTime hireDate, 
                    string contractType, string area, 
                    string jobPosition, string educationLevel)
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

    public void Terminate(string reason, string observation, string documents)
    {
        Status = "TERMINATED";
        TerminationReason = reason;
        TerminationObservation = observation;
        TerminationDocuments = documents;
        TerminatedAt = DateTime.UtcNow;
    }

    public void Reactivate(string newArea, string newPosition, string newContractType)
    {
        Status = "ACTIVE";
        Area = newArea;
        JobPosition = newPosition;
        ContractType = newContractType;
        ReactivatedAt = DateTime.UtcNow;
        
        TerminationReason = null;
        TerminationObservation = null;
        TerminationDocuments = null;
    }
}