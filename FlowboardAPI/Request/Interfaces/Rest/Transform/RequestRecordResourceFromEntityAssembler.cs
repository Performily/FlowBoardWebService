using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Interfaces.Rest.Resources;

namespace FlowboardAPI.Requests.Interfaces.Rest.Transform;

public static class RequestRecordResourceFromEntityAssembler
{
    public static RequestRecordResource ToResourceFromEntity(RequestRecord entity)
    {
        return new RequestRecordResource(
            entity.Id,
            entity.EmployeeId,
            entity.Type.ToString(),
            entity.Status.ToString(),
            entity.Justification?.Reason ?? string.Empty,
            entity.Period?.StartDate,
            entity.Period?.EndDate,
            entity.Period?.TotalDays ?? 0,
            entity.TimeFrame?.Date,
            entity.TimeFrame?.StartTime?.ToString(@"hh\:mm\:ss"),
            entity.TimeFrame?.EndTime?.ToString(@"hh\:mm\:ss"),
            entity.TimeFrame?.TotalHours ?? 0,
            entity.Evidence?.DocumentUrl ?? string.Empty,
            entity.CreatedAt,
            entity.ReviewDetails?.ReviewerId,
            entity.ReviewDetails?.RejectionReason
        );
    }
}