namespace FlowboardAPI.Attendance.Interfaces.Rest.Resources;

public record AttendanceRecordResource(
    int Id,
    int EmployeeId,
    string BiometricId,
    DateTime Timestamp,
    string Status);