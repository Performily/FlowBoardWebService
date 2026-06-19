namespace FlowboardAPI.Requests.Domain.Model.ValueObjects;

public record Justification(string Reason)
{
    public Justification() : this(string.Empty) { }
}