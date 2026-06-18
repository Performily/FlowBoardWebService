using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Application.Model;
using FlowboardAPI.Shared.Interfaces.Rest.ProblemDetails;
using FlowboardAPI.Shared.Resources.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace FlowboardAPI.Payroll.Interfaces.Rest.Transform;

public static class PaySlipActionResultAssembler
{
    public static IActionResult ToActionResultFromGetByIdResult(
        ControllerBase controller,
        PaySlip? paySlip,
        IStringLocalizer<ErrorMessages> localizer,
        ProblemDetailsFactory factory,
        Func<PaySlip, IActionResult> success)
    {
        if (paySlip is null)
            return controller.NotFound(factory.CreateProblemDetails(controller, 404, (Enum?)null, "Pay slip not found."));

        return success(paySlip);
    }

    public static IActionResult ToActionResultFromCreateResult(
        ControllerBase controller,
        Result<PaySlip> result,
        IStringLocalizer<ErrorMessages> localizer,
        ProblemDetailsFactory factory,
        Func<PaySlip, IActionResult> success)
    {
        if (!result.IsSuccess)
            return controller.BadRequest(factory.CreateProblemDetails(controller, 400, result.Error, result.Message));

        return success(result.Value!);
    }

    public static IActionResult ToActionResultFromUpdateResult(
        ControllerBase controller,
        Result<PaySlip> result,
        IStringLocalizer<ErrorMessages> localizer,
        ProblemDetailsFactory factory,
        Func<PaySlip, IActionResult> success)
    {
        if (!result.IsSuccess)
        {
            var statusCode = result.Message.Contains("not found", StringComparison.OrdinalIgnoreCase) ? 404 : 400;
            return controller.StatusCode(statusCode, factory.CreateProblemDetails(controller, statusCode, result.Error, result.Message));
        }

        return success(result.Value!);
    }
}