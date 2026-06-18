namespace FlowboardAPI.Requests.Interfaces.Rest.Resources;

public record RequestRecordResource(
    int Id,
    int EmployeeId,
    string Type,
    string Status,
    string Justification,
    DateTime? StartDate,
    DateTime? EndDate,
    int TotalDays,
    DateTime? TimeFrameDate,
    string? StartTime, // Convertido a string para simplificar el JSON (ej. "09:00:00")
    string? EndTime,
    int TotalHours,
    string EvidenceUrl,
    DateTime CreatedAt,
    int? ReviewerId,
    string? RejectionReason
);