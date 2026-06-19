namespace FlowboardAPI.Requests.Domain.Model.Aggregates;

public partial class RequestRecord
{
    public DateTime? UpdatedAt { get; private set; }

    public void UpdateAuditTime()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}