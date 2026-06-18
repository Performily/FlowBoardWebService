using FlowboardAPI.Payroll.Domain.Model.ValueObjects;

namespace FlowboardAPI.Payroll.Domain.Model.Aggregates;

public partial class PaySlip
{
    public void MarkAsPaid(DateTime paymentDate)
    {
        Status = EPaySlipStatus.Paid;
        PaymentDate = paymentDate;
    }

    public void MarkAsPending()
    {
        Status = EPaySlipStatus.Pending;
        PaymentDate = null;
    }

    public void MarkWithObservation()
    {
        Status = EPaySlipStatus.WithObservation;
    }

    public void UpdateStatusFromText(string status)
    {
        switch (status.Trim())
        {
            case "Pagado":
            case "Paid":
                MarkAsPaid(DateTime.UtcNow);
                break;
            case "Pendiente":
            case "Pending":
                MarkAsPending();
                break;
            case "Con observación":
            case "WithObservation":
                MarkWithObservation();
                break;
            default:
                throw new ArgumentException("Invalid pay slip status.");
        }
    }

    public string GetStatusLabel()
    {
        return Status switch
        {
            EPaySlipStatus.Paid => "Pagado",
            EPaySlipStatus.WithObservation => "Con observación",
            _ => "Pendiente"
        };
    }
}