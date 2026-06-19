using FlowboardAPI.Requests.Domain.Model.ValueObjects;

namespace FlowboardAPI.Requests.Domain.Model.Aggregates;

public partial class RequestRecord
{
    public void Approve(int reviewerId)
    {
        if (Status != ERequestStatus.Pending)
            throw new InvalidOperationException("Solo se pueden aprobar solicitudes pendientes.");

        Status = ERequestStatus.Approved;
        ReviewDetails = new ReviewDetails(reviewerId, DateTime.UtcNow, null);
        UpdateAuditTime();
    }

    public void Reject(int reviewerId, string reason)
    {
        if (Status != ERequestStatus.Pending)
            throw new InvalidOperationException("Solo se pueden rechazar solicitudes pendientes.");
            
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Se requiere un motivo para rechazar la solicitud.");

        Status = ERequestStatus.Rejected;
        ReviewDetails = new ReviewDetails(reviewerId, DateTime.UtcNow, reason);
        UpdateAuditTime();
    }

    public void Cancel()
    {
        if (Status != ERequestStatus.Pending)
            throw new InvalidOperationException("Solo se pueden cancelar solicitudes pendientes.");

        Status = ERequestStatus.Canceled;
        UpdateAuditTime();
    }
}