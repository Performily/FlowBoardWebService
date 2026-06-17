using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Application.Model; 
using FlowboardAPI.Shared.Resources.Errors;
using FlowboardAPI.Shared.Interfaces.Rest.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace FlowboardAPI.Attendance.Interfaces.Rest.Transform;

public static class AttendanceRecordActionResultAssembler
{
    public static IActionResult ToActionResultFromGetByIdResult(
        ControllerBase controller, 
        AttendanceRecord? record, 
        IStringLocalizer<ErrorMessages> localizer, 
        ProblemDetailsFactory factory, 
        Func<AttendanceRecord, IActionResult> success)
    {
        if (record == null) return controller.NotFound(factory.CreateProblemDetails(controller, 404 ,(Enum?)null, "Attendance record not found."));
        return success(record);
    }

    public static IActionResult ToActionResultFromCreateResult(
        ControllerBase controller, 
        Result<AttendanceRecord> result, // <- Cambiado de 'AttendanceRecord?' a 'Result<AttendanceRecord>'
        IStringLocalizer<ErrorMessages> localizer, 
        ProblemDetailsFactory factory, 
        Func<AttendanceRecord, IActionResult> success)
    {
        // 1. Verificamos si el resultado fue fallido (adaptado a las propiedades de tu Result, ej: !result.IsSuccess)
        if (!result.IsSuccess) 
        {
            return controller.BadRequest(factory.CreateProblemDetails(
                controller, 
                400, (Enum?)null,
                "Could not register attendance record."));
        }

        // 2. Si fue exitoso, le pasamos el valor interno (.Value) a la función success
        return success(result.Value!); 
    }
}