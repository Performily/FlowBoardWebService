using Microsoft.AspNetCore.Mvc;
using FlowboardAPI.Workspace.Application.CommandServices; 
using FlowboardAPI.Workspace.Application.QueryServices;   
using FlowboardAPI.Workspace.Interfaces.REST.Resources;
using FlowboardAPI.Workspace.Interfaces.REST.Transform;
using FlowboardAPI.Workspace.Domain.Model.Queries;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var getEmployeeByIdQuery = new GetEmployeeByIdQuery(id);
        var employee = await _queryService.Handle(getEmployeeByIdQuery);
        
        if (employee == null) return NotFound();

        var resource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return Ok(resource);
    }
}