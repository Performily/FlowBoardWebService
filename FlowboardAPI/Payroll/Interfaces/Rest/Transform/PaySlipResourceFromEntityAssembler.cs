using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Interfaces.Rest.Resources;

namespace FlowboardAPI.Payroll.Interfaces.Rest.Transform;

public static class PaySlipResourceFromEntityAssembler
{
    public static PaySlipResource ToResourceFromEntity(PaySlip entity)
    {
        return new PaySlipResource(
            entity.Id,
            entity.CollaboratorId,
            entity.CollaboratorName,
            entity.CollaboratorCode,
            entity.Area,
            entity.Period,
            entity.PaymentType,
            entity.GrossIncome,
            entity.Deductions,
            entity.NetIncome,
            entity.GetStatusLabel(),
            entity.IssueDate,
            entity.PaymentDate
        );
    }
}