using FlowboardAPI.Workspace.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlowboardAPI.Workspace.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")] 
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeRepository.ListAsync();
        return Ok(employees);
    }
}