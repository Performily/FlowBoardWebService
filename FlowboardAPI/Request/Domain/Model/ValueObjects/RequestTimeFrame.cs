namespace FlowboardAPI.Requests.Domain.Model.ValueObjects;

public record RequestTimeFrame(DateTime? Date, TimeSpan? StartTime, TimeSpan? EndTime, int TotalHours)
{
    public RequestTimeFrame() : this(null, null, null, 0) { }
}