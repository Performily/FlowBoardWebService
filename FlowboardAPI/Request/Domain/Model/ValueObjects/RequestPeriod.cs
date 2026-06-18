namespace FlowboardAPI.Requests.Domain.Model.ValueObjects;

public record RequestPeriod(DateTime? StartDate, DateTime? EndDate, int TotalDays)
{
    public RequestPeriod() : this(null, null, 0) { }
}