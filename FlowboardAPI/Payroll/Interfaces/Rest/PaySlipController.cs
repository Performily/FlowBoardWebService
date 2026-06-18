using System.Net.Mime;
using FlowboardAPI.Payroll.Application.CommandServices;
using FlowboardAPI.Payroll.Application.QueryServices;
using FlowboardAPI.Payroll.Domain.Model.Commands;
using FlowboardAPI.Payroll.Domain.Model.Queries;
using FlowboardAPI.Payroll.Interfaces.Rest.Resources;
using FlowboardAPI.Payroll.Interfaces.Rest.Transform;
using FlowboardAPI.Shared.Interfaces.Rest.ProblemDetails;
using FlowboardAPI.Shared.Resources.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowboardAPI.Payroll.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Route("payslips")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Pay Slip Endpoints.")]
public class PaySlipsController(
    IPaySlipCommandService paySlipCommandService,
    IPaySlipQueryService paySlipQueryService,
    IStringLocalizer<ErrorMessages> errorLocalizer,
    ProblemDetailsFactory problemDetailsFactory)
    : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get Pay Slips", "Get pay slips with optional period, status and search filters.", OperationId = "GetPaySlips")]
    [SwaggerResponse(200, "Pay slips were retrieved successfully.", typeof(IEnumerable<PaySlipResource>))]
    public async Task<IActionResult> GetPaySlips(
        [FromQuery] string? period,
        [FromQuery] string? status,
        [FromQuery(Name = "q")] string? search,
        CancellationToken cancellationToken)
    {
        var query = new GetPaySlipsQuery(period, status, search);
        var paySlips = await paySlipQueryService.Handle(query, cancellationToken);

        var resources = paySlips.Select(PaySlipResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(resources);
    }

    [HttpGet("{paySlipId:int}")]
    [SwaggerOperation("Get Pay Slip by Id", "Get a pay slip by its unique identifier.", OperationId = "GetPaySlipById")]
    [SwaggerResponse(200, "The pay slip was found.", typeof(PaySlipResource))]
    [SwaggerResponse(404, "The pay slip was not found.")]
    public async Task<IActionResult> GetPaySlipById(int paySlipId, CancellationToken cancellationToken)
    {
        var query = new GetPaySlipByIdQuery(paySlipId);
        var paySlip = await paySlipQueryService.Handle(query, cancellationToken);

        return PaySlipActionResultAssembler.ToActionResultFromGetByIdResult(
            this,
            paySlip,
            errorLocalizer,
            problemDetailsFactory,
            foundPaySlip => Ok(PaySlipResourceFromEntityAssembler.ToResourceFromEntity(foundPaySlip))
        );
    }

    [HttpGet("collaborators/{collaboratorId:int}")]
    [SwaggerOperation("Get Pay Slips by Collaborator", "Get all pay slips assigned to a collaborator.", OperationId = "GetPaySlipsByCollaboratorId")]
    [SwaggerResponse(200, "Pay slips were retrieved successfully.", typeof(IEnumerable<PaySlipResource>))]
    public async Task<IActionResult> GetPaySlipsByCollaboratorId(int collaboratorId, CancellationToken cancellationToken)
    {
        var query = new GetPaySlipsByCollaboratorIdQuery(collaboratorId);
        var paySlips = await paySlipQueryService.Handle(query, cancellationToken);

        var resources = paySlips.Select(PaySlipResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation("Create Pay Slip", "Register a new collaborator pay slip.", OperationId = "CreatePaySlip")]
    [SwaggerResponse(201, "The pay slip was registered.", typeof(PaySlipResource))]
    [SwaggerResponse(400, "The pay slip could not be registered.")]
    public async Task<IActionResult> CreatePaySlip(CreatePaySlipResource resource, CancellationToken cancellationToken)
    {
        var command = CreatePaySlipCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await paySlipCommandService.Handle(command, cancellationToken);

        return PaySlipActionResultAssembler.ToActionResultFromCreateResult(
            this,
            result,
            errorLocalizer,
            problemDetailsFactory,
            createdPaySlip => CreatedAtAction(nameof(GetPaySlipById), new { paySlipId = createdPaySlip.Id },
                PaySlipResourceFromEntityAssembler.ToResourceFromEntity(createdPaySlip))
        );
    }

    [HttpPatch("{paySlipId:int}/status")]
    [SwaggerOperation("Update Pay Slip Status", "Update the status of an existing pay slip.", OperationId = "UpdatePaySlipStatus")]
    [SwaggerResponse(200, "The pay slip status was updated.", typeof(PaySlipResource))]
    [SwaggerResponse(400, "The pay slip status could not be updated.")]
    [SwaggerResponse(404, "The pay slip was not found.")]
    public async Task<IActionResult> UpdatePaySlipStatus(
        int paySlipId,
        UpdatePaySlipStatusResource resource,
        CancellationToken cancellationToken)
    {
        var command = new UpdatePaySlipStatusCommand(paySlipId, resource.Status);
        var result = await paySlipCommandService.Handle(command, cancellationToken);

        return PaySlipActionResultAssembler.ToActionResultFromUpdateResult(
            this,
            result,
            errorLocalizer,
            problemDetailsFactory,
            updatedPaySlip => Ok(PaySlipResourceFromEntityAssembler.ToResourceFromEntity(updatedPaySlip))
        );
    }
}
