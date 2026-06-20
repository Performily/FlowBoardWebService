using FlowboardAPI.Requests.Domain.Model.Commands;
using FlowboardAPI.Requests.Domain.Model.ValueObjects;
using FlowboardAPI.Requests.Interfaces.Rest.Resources;

namespace FlowboardAPI.Requests.Interfaces.Rest.Transform;

public static class CreateRequestRecordCommandFromResourceAssembler
{
    public static CreateRequestRecordCommand ToCommandFromResource(CreateRequestRecordResource resource)
    {
        // Convertimos los strings de hora a TimeSpan si existen
        TimeSpan? startTime = !string.IsNullOrEmpty(resource.StartTime) ? TimeSpan.Parse(resource.StartTime) : null;
        TimeSpan? endTime = !string.IsNullOrEmpty(resource.EndTime) ? TimeSpan.Parse(resource.EndTime) : null;

        return new CreateRequestRecordCommand(
            resource.EmployeeId,
            Enum.Parse<ERequestType>(resource.Type), // Convierte el string al Enum
            new Justification(resource.Justification ?? string.Empty),
            new RequestPeriod(resource.StartDate, resource.EndDate, resource.TotalDays),
            new RequestTimeFrame(resource.TimeFrameDate, startTime, endTime, resource.TotalHours),
            new Evidence(resource.EvidenceUrl ?? string.Empty)
        );
    }
}