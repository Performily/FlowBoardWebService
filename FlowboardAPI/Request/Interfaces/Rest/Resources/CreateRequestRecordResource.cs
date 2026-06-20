namespace FlowboardAPI.Requests.Interfaces.Rest.Resources;

public record CreateRequestRecordResource(
    int EmployeeId,
    string Type, // Ej: "Vacation", "MedicalLeave"
    string Justification,
    DateTime? StartDate,
    DateTime? EndDate,
    int TotalDays,
    DateTime? TimeFrameDate,
    string? StartTime, 
    string? EndTime,
    int TotalHours,
    string EvidenceUrl
);