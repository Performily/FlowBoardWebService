using Microsoft.AspNetCore.Mvc;
using FlowboardAPI.Workspace.Application.Internal.QueryServices;
using FlowboardAPI.Workspace.Interfaces.REST.Transform;

namespace FlowboardAPI.Workspace.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeQueryService _queryService;
    public EmployeesController(EmployeeQueryService queryService) => _queryService = queryService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _queryService.Handle();
        var resources = employees.Select(EmployeeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}