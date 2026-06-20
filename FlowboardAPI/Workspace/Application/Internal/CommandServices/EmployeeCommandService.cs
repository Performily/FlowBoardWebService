using FlowboardAPI.Shared.Domain.Repositories;
using FlowboardAPI.Workspace.Domain.Model.Aggregates;
using FlowboardAPI.Workspace.Domain.Model.Commands;
using FlowboardAPI.Workspace.Domain.Model.ValueObjects;
using FlowboardAPI.Workspace.Domain.Repositories;
using FlowboardAPI.Workspace.Application.CommandServices;
namespace FlowboardAPI.Workspace.Application.Internal.CommandServices;

public class EmployeeCommandService: IEmployeeCommandService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeCommandService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Employee?> Handle(CreateEmployeeCommand command)
    {
        var employee = new Employee(
            command.Code, command.Name, command.CivilStatus, new DocumentNumber(command.DocumentNumber), 
            command.Age, new EmailAddress(command.PersonalEmail), command.PhoneNumber, command.Address, 
            command.Gender, new EmailAddress(command.WorkEmail), command.HireDate, command.ContractType, 
            command.Area, command.JobPosition, command.EducationLevel);

        await _employeeRepository.AddAsync(employee);
        await _unitOfWork.CompleteAsync();

        return employee;
    }
}