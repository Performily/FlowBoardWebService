namespace FlowboardAPI.Requests.Domain.Model.ValueObjects;

public record ReviewDetails(int? ReviewerId, DateTime? ReviewedAt, string? RejectionReason)
{
    public ReviewDetails() : this(null, null, null) { }
}