namespace FlowboardAPI.Requests.Domain.Model.ValueObjects;

public record Evidence(string DocumentUrl)
{
    public Evidence() : this(string.Empty) { }
}