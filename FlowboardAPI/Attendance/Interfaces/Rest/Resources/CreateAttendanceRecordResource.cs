namespace FlowboardAPI.Attendance.Interfaces.Rest.Resources;

public record CreateAttendanceRecordResource(
    int EmployeeId,
    string BiometricId,
    DateTime Timestamp);