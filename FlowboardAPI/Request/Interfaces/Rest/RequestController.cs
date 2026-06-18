using System.Net.Mime;
using FlowboardAPI.Requests.Application.CommandServices;
using FlowboardAPI.Requests.Application.QueryServices;
using FlowboardAPI.Requests.Domain.Model.Commands;
using FlowboardAPI.Requests.Domain.Model.Queries;
using FlowboardAPI.Requests.Interfaces.Rest.Resources;
using FlowboardAPI.Requests.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FlowboardAPI.Requests.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RequestController(
    IRequestCommandService requestCommandService,
    IRequestQueryService requestQueryService) : ControllerBase
{
    // POST: api/v1/request
    [HttpPost]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestRecordResource resource)
    {
        var command = CreateRequestRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await requestCommandService.Handle(command, CancellationToken.None);

        if (!result.IsSuccess) return BadRequest(result.Message); // Corregido aquí

        var requestResource = RequestRecordResourceFromEntityAssembler.ToResourceFromEntity(result.Value!); // Corregido aquí
        return CreatedAtAction(nameof(GetRequestById), new { id = requestResource.Id }, requestResource);
    }

    // GET: api/v1/request/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRequestById(int id)
    {
        var query = new GetRequestByIdQuery(id);
        var requestRecord = await requestQueryService.Handle(query, CancellationToken.None);

        if (requestRecord == null) return NotFound();

        var resource = RequestRecordResourceFromEntityAssembler.ToResourceFromEntity(requestRecord);
        return Ok(resource);
    }

    // GET: api/v1/request/employee/{employeeId}
    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetRequestsByEmployeeId(int employeeId)
    {
        var query = new GetRequestByEmployeeIdQuery(employeeId);
        var requests = await requestQueryService.Handle(query, CancellationToken.None);

        var resources = requests.Select(RequestRecordResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // POST: api/v1/request/{id}/approve
    [HttpPost("{id}/approve")]
    public async Task<IActionResult> ApproveRequest(int id, [FromBody] int reviewerId)
    {
        var command = new ApproveRequestCommand(id, reviewerId);
        var result = await requestCommandService.Handle(command, CancellationToken.None);

        if (!result.IsSuccess) return BadRequest(result.Message); // Corregido aquí

        var resource = RequestRecordResourceFromEntityAssembler.ToResourceFromEntity(result.Value!); // Corregido aquí
        return Ok(resource);
    }

    // POST: api/v1/request/{id}/reject
    [HttpPost("{id}/reject")]
    public async Task<IActionResult> RejectRequest(int id, [FromBody] RejectRequestResource resource)
    {
        var command = new RejectRequestCommand(id, resource.ReviewerId, resource.Reason);
        var result = await requestCommandService.Handle(command, CancellationToken.None);

        if (!result.IsSuccess) return BadRequest(result.Message); // Corregido aquí

        var responseResource = RequestRecordResourceFromEntityAssembler.ToResourceFromEntity(result.Value!); // Corregido aquí
        return Ok(responseResource);
    }

    // POST: api/v1/request/{id}/cancel
    [HttpPost("{id}/cancel")]
    public async Task<IActionResult> CancelRequest(int id)
    {
        var command = new CancelRequestCommand(id);
        var result = await requestCommandService.Handle(command, CancellationToken.None);

        if (!result.IsSuccess) return BadRequest(result.Message); // Corregido aquí

        var resource = RequestRecordResourceFromEntityAssembler.ToResourceFromEntity(result.Value!); // Corregido aquí
        return Ok(resource);
    }
}