using System.Net.Mime;
using FlowboardAPI.Attendance.Application.CommandServices;
using FlowboardAPI.Attendance.Application.QueryServices;
using FlowboardAPI.Attendance.Domain.Model.Queries;
using FlowboardAPI.Attendance.Interfaces.Rest.Resources;
using FlowboardAPI.Attendance.Interfaces.Rest.Transform;
using FlowboardAPI.Shared.Resources.Errors;
using FlowboardAPI.Shared.Interfaces.Rest.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowboardAPI.Attendance.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Attendance Record Endpoints.")]
public class AttendanceController(
    IAttendanceCommandService attendanceCommandService,
    IAttendanceQueryService attendanceQueryService,
    IStringLocalizer<ErrorMessages> errorLocalizer, 
    ProblemDetailsFactory problemDetailsFactory) 
    : ControllerBase
{   
   
    [HttpGet]
    [SwaggerOperation("Get All Attendance Summaries", "Get a daily summary of all attendance records.", OperationId = "GetAllAttendanceSummaries")]
    [SwaggerResponse(200, "The attendance summaries were found.", typeof(IEnumerable<AttendanceSummaryResource>))]
    public async Task<IActionResult> GetAllAttendances(CancellationToken cancellationToken)
    {
        var query = new GetAllAttendanceSummariesQuery();
        var summaries = await attendanceQueryService.Handle(query, cancellationToken);

        return Ok(summaries);
    }

    [HttpGet("{attendanceId:int}")]
    [SwaggerOperation("Get Attendance Record by Id", "Get an attendance record by its unique identifier.", OperationId = "GetAttendanceRecordById")]
    [SwaggerResponse(200, "The attendance record was found.", typeof(AttendanceRecordResource))]
    [SwaggerResponse(404, "The attendance record was not found.")]
    public async Task<IActionResult> GetAttendanceRecordById(int attendanceId, CancellationToken cancellationToken)
    {
        var query = new GetAttendanceByIdQuery(attendanceId);
        var record = await attendanceQueryService.Handle(query, cancellationToken);

        return AttendanceRecordActionResultAssembler.ToActionResultFromGetByIdResult(
            this,
            record,
            errorLocalizer,
            problemDetailsFactory,
            foundRecord => Ok(AttendanceRecordResourceFromEntityAssembler.ToResourceFromEntity(foundRecord))
        );
    }

    [HttpPost]
    [SwaggerOperation("Create Attendance Record", "Register a new biometric employee attendance.", OperationId = "CreateAttendanceRecord")]
    [SwaggerResponse(201, "The attendance record was registered.", typeof(AttendanceRecordResource))]
    [SwaggerResponse(400, "The attendance record could not be registered.")]
    public async Task<IActionResult> CreateAttendanceRecord(CreateAttendanceRecordResource resource, CancellationToken cancellationToken)
    {
        var command = CreateAttendanceRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await attendanceCommandService.Handle(command, cancellationToken);

        return AttendanceRecordActionResultAssembler.ToActionResultFromCreateResult(
            this,
            result,
            errorLocalizer,
            problemDetailsFactory,
            createdRecord => CreatedAtAction(nameof(GetAttendanceRecordById), new { attendanceId = createdRecord.Id },
                AttendanceRecordResourceFromEntityAssembler.ToResourceFromEntity(createdRecord))
        );
    }
}