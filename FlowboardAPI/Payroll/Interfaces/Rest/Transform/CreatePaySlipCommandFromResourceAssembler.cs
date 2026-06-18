using FlowboardAPI.Payroll.Domain.Model.Commands;
using FlowboardAPI.Payroll.Interfaces.Rest.Resources;

namespace FlowboardAPI.Payroll.Interfaces.Rest.Transform;

public static class CreatePaySlipCommandFromResourceAssembler
{
    public static CreatePaySlipCommand ToCommandFromResource(CreatePaySlipResource resource)
    {
        return new CreatePaySlipCommand(
            resource.CollaboratorId,
            resource.CollaboratorName,
            resource.CollaboratorCode,
            resource.Area,
            resource.Period,
            resource.PaymentType,
            resource.GrossIncome,
            resource.Deductions,
            resource.IssueDate,
            resource.PaymentDate,
            resource.PdfFileName
        );
    }
}