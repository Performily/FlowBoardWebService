using Microsoft.AspNetCore.Mvc;
using FlowboardAPI.Workspace.Application.CommandServices; 
using FlowboardAPI.Workspace.Application.QueryServices;   
using FlowboardAPI.Workspace.Interfaces.REST.Resources;
using FlowboardAPI.Workspace.Interfaces.REST.Transform;
namespace FlowboardAPI.Workspace.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeQueryService _queryService;
    private readonly IEmployeeCommandService _commandService;

    public EmployeesController(IEmployeeQueryService queryService, IEmployeeCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeResource resource)
    {
        var command = CreateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var employee = await _commandService.Handle(command);
        
        if (employee == null) return BadRequest();

        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        
        return StatusCode(201, employeeResource); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _queryService.Handle();
        var resources = employees.Select(EmployeeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}